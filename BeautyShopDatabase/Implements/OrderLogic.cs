using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
using BeautyShopDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyShopDatabase.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Order element = model.Id.HasValue ? null : new Order();
                        if (model.Id.HasValue)
                        {
                            element = context.Orders.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                            element.ClientId = model.ClientId;
                            element.DateCreate = model.DateCreate;
                            element.DateImplement = model.DateImplement;
                            element.Price = model.Price;
                            element.Sum = model.Sum;
                            element.Status = model.Status;
                            context.SaveChanges();
                        }
                        else
                        {
                            element.ClientId = model.ClientId;
                            element.DateCreate = model.DateCreate;
                            element.DateImplement = model.DateImplement;
                            element.Price = model.Price;
                            element.Sum = model.Sum;
                            element.Status = model.Status;
                            context.Orders.Add(element);
                            context.SaveChanges();
                            var groupServices = model.OrderServices
                               .GroupBy(rec => rec.ServiceId)
                               .Select(rec => new
                               {
                                   ServiceId = rec.Key,
                                   Count = rec.Sum(r => r.Count)
                               });

                            foreach (var groupService in groupServices)
                            {
                                context.OrderServices.Add(new OrderService
                                {
                                    OrderId = element.Id,
                                    ServiceId = groupService.ServiceId,
                                    Count = groupService.Count
                                });
                                context.SaveChanges();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new Database())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id.Value);

                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Orders.Where(rec => rec.Id == model.Id || (rec.ClientId == model.ClientId))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    Price = rec.Price,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Sum = context.Payments.Where(recP => recP.OrderId == rec.Id).Select(recP => recP.Sum).Sum(),
                    Status = rec.Status,
                    OrderServices = GetOrderServiceViewModel(rec)
                })
            .ToList();
            }
        }

        public static List<OrderServiceViewModel> GetOrderServiceViewModel(Order order)
        {
            using (var context = new Database())
            {
                var OrderServices = context.OrderServices
                    .Where(rec => rec.OrderId == order.Id)
                    .Include(rec => rec.Service)
                    .Select(rec => new OrderServiceViewModel
                    {
                        Id = rec.Id,
                        OrderId = rec.OrderId,
                        ServiceId = rec.ServiceId,
                        Count = rec.Count
                    }).ToList();
                foreach (var service in OrderServices)
                {
                    var serviceData = context.Services.Where(rec => rec.Id == service.ServiceId).FirstOrDefault();
                    service.ServiceName = serviceData.ServiceName;
                    service.Desc = serviceData.Desc;
                    service.Price = serviceData.Price;
                }
                return OrderServices;
            }
        }
    }
}
