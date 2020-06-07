using BeautySalonBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyShopDatabase.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Sum { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<OrderService> OrderServices { get; set; }

        [Required]
        [ForeignKey("OrderId")]
        public List<Payment> Payments { get; set; }

        public virtual Client Client { get; set; }
    }
}
