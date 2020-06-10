using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonWebClient.Models
{
    public class CreateOrderModel
    {
        public Dictionary<int, int> OrderServices { get; set; }
    }
}
