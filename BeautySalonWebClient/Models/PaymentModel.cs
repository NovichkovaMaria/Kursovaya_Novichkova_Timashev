using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonWebClient.Models
{
    public class PaymentModel
    {
        [Required]
        public int Sum { get; set; }
        public int OrderId { get; set; }
    }
}
