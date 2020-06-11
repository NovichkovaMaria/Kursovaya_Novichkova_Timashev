using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string FileName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
