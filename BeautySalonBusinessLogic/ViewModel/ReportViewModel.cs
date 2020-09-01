using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.ViewModel
{
    public class ReportViewModel
    {
        public string ClientFIO { get; set; }

        public int OrderId { get; set; }

        public DateTime DatePayment { get; set; }

        public int Sum { get; set; }
    }
}
