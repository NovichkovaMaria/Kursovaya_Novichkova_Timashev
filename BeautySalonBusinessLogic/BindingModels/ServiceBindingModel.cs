using System.ComponentModel;
using System.Runtime.Serialization;

namespace BeautySalonBusinessLogic.BindingModels
{
    [DataContract]
    public class ServiceBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string Desc { get; set; }

        [DataMember]
        public int Price { get; set; }
    }
}
