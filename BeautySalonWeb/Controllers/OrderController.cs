using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.BuisnessLogics;
using BeautySalonBusinessLogic.Enums;
using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
using BeautySalonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderLogic _orderLogic;
        private readonly IServiceLogic _serviceLogic;
        private readonly IPaymentLogic _paymentLogic;
        private readonly ReportLogic _reportLogic;
        public OrderController(IOrderLogic orderLogic, IServiceLogic serviceLogic, IPaymentLogic paymentLogic, ReportLogic reportLogic)
        {
            _orderLogic = orderLogic;
            _serviceLogic = serviceLogic;
            _paymentLogic = paymentLogic;
            _reportLogic = reportLogic;
        }
        public IActionResult Order()
        {
            ViewBag.Orders = _orderLogic.Read(new OrderBindingModel
            {
                ClientId = Program.Client.Id
            });
            return View();
        }
        [HttpPost]
        public IActionResult Order(ReportModel model)
        {
            var paymentList = new List<PaymentViewModel>();
            var orders = new List<OrderViewModel>();
            orders = _orderLogic.Read(new OrderBindingModel
            {
                ClientId = Program.Client.Id,
                DateFrom = model.From,
                DateTo = model.To
            });
            var payments = _paymentLogic.Read(null);
            foreach (var order in orders)
            {
                foreach (var payment in payments)
                {
                    if (payment.ClientId == Program.Client.Id && payment.OrderId == order.Id)
                        paymentList.Add(payment);
                }
            }
            ViewBag.Payments = paymentList;
            ViewBag.Orders = orders;
            string fileName = "pdfreport.pdf";
            if (model.SendMail)
            {
                _reportLogic.SaveOrdersToPdfFile(fileName, new OrderBindingModel
                {
                    ClientId = Program.Client.Id,
                    DateFrom = model.From,
                    DateTo = model.To
                }, Program.Client.Email);
            }
            return View();
        }
        public IActionResult CreateOrder()
        {
            ViewBag.OrderServices = _serviceLogic.Read(null);
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrder(CreateOrderModel model)
        {
            if (!ModelState.IsValid)
            {
               var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });
                ViewBag.OrderServices = _serviceLogic.Read(null);
                return View(model);
            }
            if (model.OrderServices == null)
            {
                ViewBag.OrderServices = _serviceLogic.Read(null);
                ModelState.AddModelError("", "Услуги не выбраны");
                return View(model);
            }
            
            var orderServices = new List<OrderServiceBindingModel>();

            foreach (var service in model.OrderServices)
            {
                if (service.Value == "on")
                {
                    orderServices.Add(new OrderServiceBindingModel
                    {
                        ServiceId = service.Key,
                        Count = service.Value == "on" ? 1 : 0
                    });
                }
            }
            if (orderServices.Count == 0)
            {
                ViewBag.Products = _serviceLogic.Read(null);
                ModelState.AddModelError("", "Услуги не выбраны");
                return View(model);
            }
            _orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ClientId = Program.Client.Id,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят,
                Price = CalculateSum(orderServices),
                OrderServices = orderServices
            });
            return RedirectToAction("Order");
        }
        private int CalculateSum(List<OrderServiceBindingModel> orderServices)
        {
            int sum = 0;

            foreach (var service in orderServices)
            {
                var serviceData = _serviceLogic.Read(new ServiceBindingModel { Id = service.ServiceId }).FirstOrDefault();

                if (serviceData != null)
                {
                    for (int i = 0; i < service.Count; i++)
                        sum += serviceData.Price;
                }
            }
            return sum;
        }
        public IActionResult Payment(int id)
        {
            var order = _orderLogic.Read(new OrderBindingModel
            {
                Id = id
            }).FirstOrDefault();
            ViewBag.Order = order;
            ViewBag.Sum = CalculateSum(order);
            return View();
        }
        [HttpPost]
        public ActionResult Payment(PaymentModel model)
        {
            OrderViewModel order = _orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            }).FirstOrDefault();
            int sum = CalculateSum(order);
            if (!ModelState.IsValid)
            {
                ViewBag.Order = order;
                ViewBag.Sum = sum;
                return View(model);
            }
            if (order.Price - sum < model.Sum)
            {
                ViewBag.Order = order;
                ViewBag.Sum = order.Price - sum;
                return View(model);
            }
            _paymentLogic.CreateOrUpdate(new PaymentBindingModel
            {
                OrderId = order.Id,
                ClientId = Program.Client.Id,
                DatePayment = DateTime.Now,
                Sum = model.Sum
            });
            sum += model.Sum;
            _orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                DateCreate = order.DateCreate,
                Status = sum < order.Price ? OrderStatus.Оплачен_не_полностью : OrderStatus.Оплачен,
                Price = order.Price,
                OrderServices = order.OrderServices.Select(rec => new OrderServiceBindingModel
                {
                    Id = rec.Id,
                    OrderId = rec.OrderId,
                    ServiceId = rec.ServiceId,
                    Count = rec.Count
                }).ToList()
            });
            return RedirectToAction("Order");
        }
        private int CalculateSum(OrderViewModel order)
        {
            int paidSum = _paymentLogic.Read(new PaymentBindingModel
            {
                OrderId = order.Id
            }).Select(rec => rec.Sum).Sum();

            return paidSum;
        }
        public IActionResult SendWordReport(int id)
        {
            var order = _orderLogic.Read(new OrderBindingModel { Id = id }).FirstOrDefault();
            string fileName = "Order" + order.Id + ".docx";
            _reportLogic.SaveOrderServicesToWordFile(fileName, order, Program.Client.Email);
            return RedirectToAction("Order");
        }
        public IActionResult SendExcelReport(int id)
        {
            var order = _orderLogic.Read(new OrderBindingModel { Id = id }).FirstOrDefault();
            string fileName = "Order" + order.Id + ".xlsx";
            _reportLogic.SaveOrderServicesToExcelFile(fileName, order, Program.Client.Email);
            return RedirectToAction("Order");
        }
    }
}
