using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
using BeautySalonDatabase;
using BeautySalonDatabase.Models;
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
        public FormDiagram()
        {
            InitializeComponent();
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
            chart.Titles.Add("Диаграмма заказов");
            chart.Titles[0].Font = new Font("Utopia", 16);

            chart.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });

            Dictionary<int, int> serviceCount = new Dictionary<int, int>();
            Dictionary<int, string> serviceNames = new Dictionary<int, string>();

            using (var context = new Database())
            {
                foreach (var i in context.Services)
                {
                    serviceNames.Add(i.Id, i.ServiceName);
                    serviceCount.Add(i.Id, 0);
                }
                foreach (var i in context.OrderServices)
                {
                    serviceCount[i.ServiceId] += i.Count;
                }
            }

            // Salary series data
            chart.Series["ColumnSeries"].Points.DataBindXY(serviceNames.Values, serviceCount.Values);

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
