using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
using BeautySalonDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonDatabase.Implements
{
    public class PaymentLogic : IPaymentLogic
    {
        public void CreateOrUpdate(PaymentBindingModel model)
        {
            using (var context = new Database())
            {
                Payment element = model.Id.HasValue ? null : new Payment();
                if (model.Id.HasValue)
                {
                    element = context.Payments.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Payment();
                    context.Payments.Add(element);
                }
                element.OrderId = model.OrderId;
                element.ClientId = model.ClientId;
                element.Sum = model.Sum;
                element.DatePayment = model.DatePayment;
                context.SaveChanges();
            }
        }

        public void Delete(PaymentBindingModel model)
        {
            using (var context = new Database())
            {
                Payment element = context.Payments.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Payments.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<PaymentViewModel> Read(PaymentBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Payments
                .Where(rec => model == null || rec.Id == model.Id || rec.OrderId.Equals(model.OrderId))
                .Select(rec => new PaymentViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    DatePayment = rec.DatePayment,
                    OrderId = rec.OrderId,
                    Sum = rec.Sum
                })
                .ToList();
            }
        }
    }
}
