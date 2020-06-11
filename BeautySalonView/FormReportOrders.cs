using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.BuisnessLogics;
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

namespace BeautySalonView
{
    public partial class FormReportOrders : Form
    {
        public readonly ReportLogic logic;
        public readonly IClientLogic logicC;

        public FormReportOrders(ReportLogic logic, IClientLogic logicC)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicC = logicC;
        }

        private void buttonReportOrders_Click(object sender, EventArgs e)
        {
            if (comboBoxFIO.SelectedValue == null)
            {
                MessageBox.Show("Выберите ФИО сотрудника", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxMail.Text))
            {
                MessageBox.Show("Заполните Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!checkBoxDoc.Checked && !checkBoxXls.Checked)
            {
                MessageBox.Show("Выберите формат документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int id = Convert.ToInt32(comboBoxFIO.SelectedValue);
                var client = logicC.Read(new ClientBindingModel { Id = id });
                if (checkBoxDoc.Checked)
                { 
                    string fileName = "cчётКлиенту.docx";
                    logic.SaveOrdersToWordFile(new ReportBindingModel
                    {
                        FileName = fileName,
                        email = textBoxMail.Text,
                        id = id
                    });
                }
                if (checkBoxXls.Checked)
                {
                    string fileName = "счётКлиенту.xlsx";
                    logic.SaveOrdersToExcelFile(new ReportBindingModel
                    {
                        FileName = fileName,
                        email = textBoxMail.Text,
                        id = id
                    });
                }

                MessageBox.Show("Отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormReportOrders_Load(object sender, EventArgs e)
        {
            try
            {
                var list = logicC.Read(null);
                comboBoxFIO.DataSource = list;
                comboBoxFIO.DisplayMember = "ClientFIO";
                comboBoxFIO.ValueMember = "Id";
                comboBoxFIO.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBoxFIO.SelectedValue);
            var clients = logicC.Read(null);
            foreach (var client in clients)
            {
                if (client.Id == id)
                {
                    textBoxMail.Text = client.Email;
                }
            }
        }
    }
}
