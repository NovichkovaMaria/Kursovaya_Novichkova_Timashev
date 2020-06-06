using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BeautySalonBusinessLogic.BindingModels
{
    public class PaymentBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int ServicelId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public DateTime DatePayment { get; set; }
        [DataMember]
        public int Sum { get; set; }
    }
}
