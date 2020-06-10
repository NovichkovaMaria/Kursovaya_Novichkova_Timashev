using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BeautySalonView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var form = Container.Resolve<FormServices>();
            form.ShowDialog();
        }

        private void отчетПоВыполненнымУслугамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var form = Container.Resolve<FormReportService>();
            //form.ShowDialog();
        }
    }
}
