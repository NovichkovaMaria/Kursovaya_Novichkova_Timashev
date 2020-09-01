using BeautySalonBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautySalonBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }

        public List<ReportViewModel> Payments { get; set; }
    }
}
