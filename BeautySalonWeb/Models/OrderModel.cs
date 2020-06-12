using BeautySalonBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonWeb.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateImplement { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderServiceModel> OrderServices { get; set; }
    }
}
