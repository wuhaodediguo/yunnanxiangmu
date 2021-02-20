using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Profile;
using System.Web.UI;
using ZedGraph;
using ZedGraph.Web;

namespace CopyMFRubikCubePowerContent.Admin.Controls
{
    public partial class ZedGraph : System.Web.UI.UserControl
    {
        protected ZedGraphWeb zedGraphControl;
        private List<System.Drawing.Color> defaultColors = new List<System.Drawing.Color>();

        private int Count;

        public string FilePath;

        public string Title;

        public string XAxisTitle;

        public string YAxisTitle;

        public AnalyticsType Type;


        public List<PointPairList> DataSource = new List<PointPairList>();

        public List<double> ScaleData = new List<double>();

        public List<System.Drawing.Color> Colors = new List<System.Drawing.Color>();

        public List<string> NameList = new List<string>();

        public List<string> CurveNameList = new List<string>();

        public List<string> LabelList = new List<string>();

        public double[] CurveForBar;

        public bool IsCurveBar;

        public int ZGWidth;

        public int ZGHeight;

        public bool IsChangeColor;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.zedGraphControl.Width = this.ZGWidth;
            this.zedGraphControl.Height = this.ZGHeight;
            this.zedGraphControl.RenderGraph += new ZedGraphWebControlEventHandler(this.zedGraphControl_RenderGraph);
            this.FilePath = "~/Admin/Controls/ZedGraph/";
            this.zedGraphControl.RenderedImagePath = this.FilePath;
        }

        private void InitDefaultColors()
        {
            if (this.IsChangeColor)
            {
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 158, 158));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(167, 233, 145));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(145, 233, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 255, 145));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(211, 233, 145));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 145, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(0, 153, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 204, 0));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(76, 183, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 214, 51));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(127, 204, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 224, 102));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(166, 219, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 235, 153));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(204, 235, 255));
                this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 245, 204));
                return;
            }
            this.defaultColors.Add(System.Drawing.Color.FromArgb(0, 153, 255));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 204, 0));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(76, 183, 255));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 214, 51));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(127, 204, 255));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 224, 102));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(166, 219, 255));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 235, 153));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(204, 235, 255));
            this.defaultColors.Add(System.Drawing.Color.FromArgb(255, 245, 204));
        }

        private void InitProperty()
        {
            this.InitDefaultColors();
            if (string.IsNullOrEmpty(this.Title))
            {
                this.Title = string.Empty;
            }
            if (string.IsNullOrEmpty(this.XAxisTitle))
            {
                this.XAxisTitle = "横轴";
            }
            if (string.IsNullOrEmpty(this.YAxisTitle))
            {
                this.YAxisTitle = "纵轴";
            }
            if (this.Type == AnalyticsType.Pie)
            {
                this.Count = this.ScaleData.Count;
            }
            else
            {
                this.Count = this.DataSource.Count;
            }
            if (this.Colors.Count == 0 || this.Colors.Count != this.Count)
            {
                if (this.IsChangeColor)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        this.Colors.Add(this.defaultColors[i]);
                    }
                }
                else
                {
                    for (int j = 0; j < 10; j++)
                    {
                        this.Colors.Add(this.defaultColors[j]);
                    }
                }
            }
            if (this.NameList.Count == 0)
            {
                if (this.Type == AnalyticsType.Bar || this.Type == AnalyticsType.Line)
                {
                    for (int k = 0; k < this.DataSource[0].Count; k++)
                    {
                        this.NameList.Add((k + 1).ToString());
                    }
                }
                else
                {
                    for (int l = 0; l < this.Count; l++)
                    {
                        this.NameList.Add((l + 1).ToString());
                    }
                }
            }
            if (this.LabelList.Count == 0)
            {
                if (this.Count > 5)
                {
                    int num = 1;
                    for (int m = 0; m < this.Count; m++)
                    {
                        this.LabelList.Add("名称 " + num.ToString());
                        if (m % 2 != 0)
                        {
                            num++;
                        }
                    }
                    return;
                }
                for (int n = 0; n < this.Count; n++)
                {
                    this.LabelList.Add("名称 " + (n + 1).ToString());
                }
            }
        }

        private void zedGraphControl_RenderGraph(ZedGraphWeb webObject, System.Drawing.Graphics g, MasterPane pane)
        {
            this.InitProperty();
            GraphPane graphPane = pane[0];
            if (this.Title != string.Empty)
            {
                graphPane.Title.Text = this.Title;
            }
            graphPane.XAxis.Title.Text = this.XAxisTitle;
            graphPane.YAxis.Title.Text = this.YAxisTitle;
            graphPane.Border.Color = System.Drawing.Color.White;
            switch (this.Type)
            {
                case AnalyticsType.Line:
                    this.DrawLine(graphPane);
                    break;
                case AnalyticsType.Bar:
                    this.DrawBar(graphPane);
                    break;
                case AnalyticsType.Pie:
                    this.DrawPie(graphPane);
                    break;
            }
            pane.AxisChange(g);
        }

        private void CreateBarLabels(GraphPane graphPane, string valueFormat, List<double> valueDouble)
        {
            for (int i = 0; i < valueDouble.Count; i++)
            {
                PointPair pointPair = new PointPair((double)(i + 1), valueDouble[i]);
                TextObj textObj = new TextObj(pointPair.Y.ToString(valueFormat), pointPair.X, (pointPair.Y > 10.0) ? (pointPair.Y - 10.0) : pointPair.Y, CoordType.AxisXYScale, AlignH.Left, AlignV.Center);
                textObj.Location.CoordinateFrame = CoordType.AxisXY2Scale;
                textObj.Location.AlignH = AlignH.Center;
                textObj.Location.AlignV = AlignV.Center;
                graphPane.GraphObjList.Add(textObj);
            }
        }

        private void DrawLine(GraphPane graphPane)
        {
            for (int i = 0; i < this.Count; i++)
            {
                LineItem lineItem = graphPane.AddCurve(this.CurveNameList[i], this.DataSource[i], this.Colors[i], SymbolType.Circle);
                lineItem.Line.Fill = new Fill(this.Colors[i], System.Drawing.Color.Transparent, -45f);
            }
            graphPane.XAxis.MajorTic.IsBetweenLabels = true;
            string[] textLabels = this.NameList.ToArray();
            graphPane.XAxis.Scale.TextLabels = textLabels;
            graphPane.XAxis.Type = AxisType.Text;
            graphPane.Fill = new Fill(System.Drawing.Color.White, System.Drawing.Color.White, 45f);
        }

        private void DrawBar(GraphPane graphPane)
        {
            if (this.IsCurveBar)
            {
                graphPane.AddCurve("公司名称", null, this.CurveForBar, System.Drawing.Color.Black, SymbolType.Circle);
                List<double> list = new List<double>();
                for (int i = 0; i < this.CurveForBar.Length; i++)
                {
                    list.Add(this.CurveForBar[i]);
                }
                this.CreateBarLabels(graphPane, "f1", list);
            }
            for (int j = 0; j < this.Count; j++)
            {
                BarItem barItem = graphPane.AddBar(this.LabelList[j], this.DataSource[j], this.Colors[j]);
                barItem.Bar.Border = new Border(false, System.Drawing.Color.Black, 0f);
                barItem.Bar.Fill = new Fill(this.Colors[j]);
            }
            graphPane.XAxis.MajorTic.IsBetweenLabels = true;
            string[] textLabels = this.NameList.ToArray();
            graphPane.XAxis.Scale.TextLabels = textLabels;
            graphPane.XAxis.Type = AxisType.Text;
            graphPane.Fill = new Fill(System.Drawing.Color.White, System.Drawing.Color.FromArgb(235, 235, 238), 45f);
        }

        private void DrawPie(GraphPane graphPane)
        {
            graphPane.Fill = new Fill(System.Drawing.Color.White, System.Drawing.Color.White, 45f);
            graphPane.Legend.Position = LegendPos.Right;
            graphPane.Legend.Location = new Location(0.949999988079071, 0.15000000596046448, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            graphPane.Legend.Border.Color = System.Drawing.Color.White;
            graphPane.Legend.FontSpec.Size = 20f;
            graphPane.Legend.IsHStack = false;
            graphPane.Title.FontSpec.Size = 30f;
            for (int i = 0; i < this.Count; i++)
            {
                PieItem pieItem = graphPane.AddPieSlice(this.ScaleData[i], this.Colors[i], this.Colors[i], 45f, 0.0, this.NameList[i]);
                pieItem.LabelDetail.FontSpec.Size = 22f;
                pieItem.LabelType = PieLabelType.Value;
            }
        }

        private void DrawMessage(GraphPane graphPane, string message)
        {
            TextObj textObj = new TextObj(message, 200.0, 200.0);
            textObj.Text = message;
            graphPane.GraphObjList.Add(textObj);
        }
    }

    public enum AnalyticsType
    {
        Line,
        Bar,
        Pie
    }
}