﻿using BeautySalonBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
