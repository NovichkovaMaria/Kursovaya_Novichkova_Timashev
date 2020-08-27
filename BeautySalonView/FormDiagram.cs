using BeautySalonBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BeautySalonView
{
    public partial class FormDiagram : Form
    {
        private readonly IOrderLogic logic;

        public FormDiagram(IOrderLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormDiagram_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();
            // Форматировать диаграмму
            chart.BackColor = Color.Gray;
            chart.BackSecondaryColor = Color.WhiteSmoke;
            chart.BackGradientStyle = GradientStyle.DiagonalRight;

            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineColor = Color.Gray;
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            // Форматировать область диаграммы
            chart.ChartAreas[0].BackColor = Color.Wheat;

            // Добавить и форматировать заголовок
            chart.Titles.Add("Диаграммы");
            chart.Titles[0].Font = new Font("Utopia", 16);

            chart.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });



            // Salary series data
            double[] yValues = { 2222, 2724, 2720, 3263, 2445 };
            string[] xValues = { "France", "Canada", "Germany", "USA", "Italy" };
            chart.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
