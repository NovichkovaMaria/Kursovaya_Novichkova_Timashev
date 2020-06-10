using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonDatabase.Models
{
    public class OrderService
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ServiceId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Service Service { get; set; }
    }
}
