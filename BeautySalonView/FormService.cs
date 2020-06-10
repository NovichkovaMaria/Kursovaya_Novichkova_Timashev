using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
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
    public partial class FormService : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }
        private readonly IServiceLogic logic;
        private int? id;

        public FormService(IServiceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (textBoxName.Text != "" && textBoxPrice.Text != "" && textBoxDesc.Text != "")
            {
                logic.CreateOrUpdate(new ServiceBindingModel
                {
                    Id = id,
                    ServiceName = textBoxName.Text,
                    Desc = textBoxDesc.Text,
                    Price = Convert.ToInt32(textBoxPrice.Text)
                });
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
