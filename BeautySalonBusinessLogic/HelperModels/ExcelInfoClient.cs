using BeautySalonBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.HelperModels
{
    public class ExcelInfoClient
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ServiceViewModel> Services { get; set; }
    }
}
