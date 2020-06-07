using BeautySalonBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BeautySalonBusinessLogic.ViewModel
{
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [DisplayName("Дата посещения")]
        public DateTime? DateImplement { get; set; }

        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public int Price { get; set; }

        [DataMember]
        [DisplayName("Оплачено")]
        public int Sum { get; set; }

        [DataMember]
        public List<OrderServiceViewModel> OrderServices { get; set; }
    }
}
