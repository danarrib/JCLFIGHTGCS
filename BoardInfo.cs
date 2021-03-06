using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace JCFLIGHTGCS
{
    public partial class BoardInfo : Form
    {
        PointPairList Chart1 = new PointPairList();
        PointPairList Chart2 = new PointPairList();
        PointPairList Chart3 = new PointPairList();
        PointPairList Chart4 = new PointPairList();
        PointPairList Chart5 = new PointPairList();
        PointPairList Chart6 = new PointPairList();

        static double TimeStamp = 0;

        static Scale aScale;

        public BoardInfo()
        {
            InitializeComponent();
        }

        private void BoardInfo_Load(object sender, EventArgs e)
        {
            TimeStamp = 0;
            CreateChart(zedGraphControl1);
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();
        }

        public void CreateChart(ZedGraphControl ZedGraph)
        {
            GraphPane Pane = ZedGraph.GraphPane;
            LineItem Curve;
            Pane.Title.Text = "Analisador Gráfico";
            Pane.XAxis.Title.Text = "";
            Pane.YAxis.Title.Text = "Valor";
            Curve = Pane.AddCurve("Vazio", Chart1, Color.Red, SymbolType.None);
            Curve = Pane.AddCurve("Vazio", Chart2, Color.LightGreen, SymbolType.None);
            Curve = Pane.AddCurve("Vazio", Chart3, Color.LightBlue, SymbolType.None);
            Curve = Pane.AddCurve("Vazio", Chart4, Color.Pink, SymbolType.None);
            Curve = Pane.AddCurve("Vazio", Chart5, Color.Yellow, SymbolType.None);
            Curve = Pane.AddCurve("Vazio", Chart6, Color.Orange, SymbolType.None);
            Pane.XAxis.MajorGrid.IsVisible = true;
            Pane.YAxis.Scale.FontSpec.FontColor = Color.White;
            Pane.YAxis.Title.FontSpec.FontColor = Color.White;
            Pane.YAxis.MajorTic.IsOpposite = false;
            Pane.YAxis.MinorTic.IsOpposite = false;
            Pane.YAxis.MajorGrid.IsZeroLine = true;
            Pane.YAxis.Scale.Align = AlignP.Inside;
            Pane.Chart.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            Pane.Fill = new Fill(Color.DimGray, Color.DimGray, 45.0f);
            Pane.Legend.Fill = new Fill(Color.White, Color.White, 0);
            Pane.Legend.FontSpec.FontColor = Color.White;
            foreach (LineItem li in Pane.CurveList)
            {
                li.Line.Width = 1;
            }
            Pane.XAxis.MajorTic.Color = Color.White;
            Pane.XAxis.MinorTic.Color = Color.White;
            Pane.YAxis.MajorTic.Color = Color.White;
            Pane.YAxis.MinorTic.Color = Color.White;
            Pane.XAxis.MajorGrid.Color = Color.White;
            Pane.YAxis.MajorGrid.Color = Color.White;
            Pane.YAxis.Scale.FontSpec.FontColor = Color.White;
            Pane.YAxis.Title.FontSpec.FontColor = Color.White;
            Pane.XAxis.Scale.FontSpec.FontColor = Color.White;
            Pane.XAxis.Title.FontSpec.FontColor = Color.White;
            Pane.Legend.Fill = new Fill(Color.FromArgb(0x85, 0x84, 0x83));
            Pane.Legend.Position = LegendPos.TopCenter;
            Pane.XAxis.Scale.Min = 0;
            Pane.XAxis.Scale.Max = 300;
            Pane.XAxis.Type = AxisType.Linear;
            aScale = zedGraphControl1.GraphPane.XAxis.Scale;
            try
            { zedGraphControl1.AxisChange(); }
            catch { }
        }

        private void Graphit()
        {
            TimeStamp = TimeStamp + 1;

            if (TimeStamp > aScale.Max)
            {
                double range = aScale.Max - aScale.Min;
                aScale.Max = aScale.Max + 1;
                aScale.Min = aScale.Max - range;
            }

            try
            {
                if (checkBox1.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = "Acc Pitch (Sem Filtro)";
                    Chart1.Add(TimeStamp, GetValues.AccNotFilteredY);
                }

                if (checkBox2.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = "Acc Roll (Sem Filtro)";
                    Chart2.Add(TimeStamp, GetValues.AccNotFilteredX);
                }

                if (checkBox3.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = "Acc Yaw (Sem Filtro)";
                    Chart3.Add(TimeStamp, GetValues.AccNotFilteredZ);
                }

                if (checkBox4.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = "Acc Pitch (Com Filtro)";
                    Chart4.Add(TimeStamp, GetValues.AccFilteredY);
                }

                if (checkBox5.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = "Acc Roll (Com Filtro)";
                    Chart5.Add(TimeStamp, GetValues.AccFilteredX);
                }

                if (checkBox6.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = "Acc Yaw (Com Filtro)";
                    Chart6.Add(TimeStamp, GetValues.AccFilteredZ);
                }

                if (checkBox7.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = "Gyro Roll (Sem Filtro)";
                    Chart1.Add(TimeStamp, GetValues.GyroNotFilteredX);
                }

                if (checkBox8.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = "Gyro Pitch (Sem Filtro)";
                    Chart2.Add(TimeStamp, GetValues.GyroNotFilteredY);
                }

                if (checkBox9.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = "Gyro Yaw (Sem Filtro)";
                    Chart3.Add(TimeStamp, GetValues.GyroNotFilteredZ);
                }

                if (checkBox10.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = "Gyro Roll (Com Filtro)";
                    Chart4.Add(TimeStamp, GetValues.GyroFilteredX);
                }

                if (checkBox11.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = "Gyro Pitch (Com Filtro)";
                    Chart5.Add(TimeStamp, GetValues.GyroFilteredY);
                }

                if (checkBox12.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = "Gyro Yaw (Com Filtro)";
                    Chart6.Add(TimeStamp, GetValues.GyroFilteredZ);
                }

                if (checkBox13.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = "Mag Roll";
                    Chart1.Add(TimeStamp, GetValues.CompassX);
                }

                if (checkBox14.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = "Mag Pitch";
                    Chart2.Add(TimeStamp, GetValues.CompassY);
                }

                if (checkBox15.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = "Mag Yaw";
                    Chart3.Add(TimeStamp, GetValues.CompassZ);
                }

                if (checkBox17.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = "Altitude(Baro)";
                    Chart4.Add(TimeStamp, GetValues.ReadBarometer);
                }

                if (checkBox18.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = "Tubo de Pitot(KM/h)";
                    Chart5.Add(TimeStamp, Convert.ToDouble(GetValues.ReadAirSpeed / 27.778f));
                }

                if (checkBox19.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = "Erros I2C";
                    Chart6.Add(TimeStamp, GetValues.ReadI2CError);
                }

                if (checkBox20.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = "Tensão";
                    Chart1.Add(TimeStamp, GetValues.ReadBattVoltage);
                }

                if (checkBox21.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = "Porcentagem";
                    Chart2.Add(TimeStamp, GetValues.ReadBattPercentage);
                }

                if (checkBox22.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = "Corrente";
                    Chart3.Add(TimeStamp, GetValues.ReadBattCurrent);
                }

                if (checkBox16.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = "Watts";
                    Chart4.Add(TimeStamp, GetValues.ReadBattWatts);
                }

                if (checkBox23.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = "GroudSpeed (GPS)";
                    Chart5.Add(TimeStamp, GetValues.ReadGroundSpeed);
                }

                if (checkBox24.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = "GroudCourse (GPS)";
                    Chart6.Add(TimeStamp, GetValues.ReadGroundCourse);
                }

                if (checkBox27.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = "Attitude Roll";
                    Chart1.Add(TimeStamp, GetValues.ReadAttitudeRoll);
                }

                if (checkBox26.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = "Attitude Pitch";
                    Chart2.Add(TimeStamp, GetValues.ReadAttitudePitch);
                }

                if (checkBox25.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = "Attitude Yaw";
                    Chart3.Add(TimeStamp, GetValues.ReadAttitudeYaw);
                }

                if (checkBox28.Checked)
                {
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = "Temperatura (Baro)";
                    Chart4.Add(TimeStamp, GetValues.ReadTemperature);
                }

            }
            catch { }
            try { zedGraphControl1.AxisChange(); }
            catch { }
            zedGraphControl1.ZoomOutAll(zedGraphControl1.GraphPane);
            zedGraphControl1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphit();
            label1.Text = "Acc Pitch(Sem Filtro):" + GetValues.AccNotFilteredX;
            label2.Text = "Acc Roll(Sem Filtro):" + GetValues.AccNotFilteredY;
            label3.Text = "Acc Yaw(Sem Filtro):" + GetValues.AccNotFilteredZ;
            label23.Text = "Acc Pitch(Com Filtro):" + GetValues.AccFilteredX;
            label22.Text = "Acc Roll(Com Filtro):" + GetValues.AccFilteredY;
            label17.Text = "Acc Yaw(Com Filtro):" + GetValues.AccFilteredZ;
            label4.Text = "Gyro Roll(Sem Filtro):" + GetValues.GyroNotFilteredX;
            label5.Text = "Gyro Pitch(Sem Filtro):" + GetValues.GyroNotFilteredY;
            label6.Text = "Gyro Yaw(Sem Filtro):" + GetValues.GyroNotFilteredZ;
            label26.Text = "Gyro Roll(Com Filtro):" + GetValues.GyroFilteredX;
            label25.Text = "Gyro Pitch(Com Filtro):" + GetValues.GyroFilteredY;
            label24.Text = "Gyro Yaw(Com Filtro):" + GetValues.GyroFilteredZ;
            label7.Text = "Mag Roll:" + GetValues.CompassX;
            label8.Text = "Mag Pitch:" + GetValues.CompassY;
            label9.Text = "Mag Yaw:" + GetValues.CompassZ;
            label11.Text = "Altitude(Baro):" + GetValues.ReadBarometer;
            label18.Text = "Tensão:" + GetValues.ReadBattVoltage;
            label27.Text = "Porcentagem:" + GetValues.ReadBattPercentage;
            label19.Text = "Corrente:" + GetValues.ReadBattCurrent;
            label10.Text = "Watts:" + GetValues.ReadBattWatts;
            label30.Text = "Attitude Roll:" + GetValues.ReadAttitudeRoll;
            label29.Text = "Attitude Pitch:" + GetValues.ReadAttitudePitch;
            label28.Text = "Attitude Yaw:" + GetValues.ReadAttitudeYaw;
            label31.Text = "Temperatura(Baro):" + GetValues.ReadTemperature;
            label15.Text = "Tubo de Pitot(KM/h):" + Convert.ToDouble(GetValues.ReadAirSpeed / 27.778f).ToString("0.00");
            label16.Text = "Erros I2C:" + GetValues.ReadI2CError;
            label20.Text = "GroudSpeed(GPS):" + GetValues.ReadGroundSpeed;
            label21.Text = "GroudCourse (GPS):" + GetValues.ReadGroundCourse;
        }
    }
}
