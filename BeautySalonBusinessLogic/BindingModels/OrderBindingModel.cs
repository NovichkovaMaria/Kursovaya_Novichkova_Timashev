using BeautySalonBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BeautySalonBusinessLogic.BindingModels
{
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public DateTime? DateImplement { get; set; }

        [DataMember]
        public OrderStatus Status { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int Sum { get; set; }

        [DataMember]
        public List<OrderServiceBindingModel> OrderServices { get; set; }
    }
}
