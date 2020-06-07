using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeautySalonBusinessLogic.ViewModel
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }

        [DisplayName("Описание услуги")]
        public string Desc { get; set; }

        [DisplayName("Цена")]
        public int Price { get; set; }
    }
}
