using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BeautySalonBusinessLogic.BindingModels
{
    [DataContract]
    public class OrderServiceBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ServiceId { get; set; }

        [DataMember]
        public int? OrderId { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string Desc { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
