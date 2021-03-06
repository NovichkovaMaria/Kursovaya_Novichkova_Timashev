﻿using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.BuisnessLogics;
using BeautySalonBusinessLogic.ViewModel;
using BeautySalonDatabase.Implements;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Reporting.WinForms;
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
    public partial class FormReportPayment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly ClientLogic logicC;
        public FormReportPayment(ReportLogic logic, ClientLogic logicC)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicC = logicC;
        }

        private void FormReportPayment_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }

        public void LoadData()
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod", "c " + dateTimePickerFrom.Value.ToShortDateString() + " по " + dateTimePickerTo.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameter);

                var dataSource = logic.GetPayments(new ReportBindingModel { DateFrom = dateTimePickerFrom.Value.Date, DateTo = dateTimePickerTo.Value.Date });

                ReportDataSource source = new ReportDataSource("DataSetPayments", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            this.reportViewer.RefreshReport();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SavePaymentsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = dateTimePickerFrom.Value,
                            DateTo = dateTimePickerTo.Value
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
