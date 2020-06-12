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
                List<PaymentViewModel> result = new List<PaymentViewModel>();

                if (model != null)
                {
                    result.AddRange(context.Payments
                        .Where(rec => rec.Id == model.Id || rec.OrderId == model.OrderId 
                        || (model.DateFrom != null && model.DateTo != null) 
                        && (rec.DatePayment > model.DateFrom && (rec.DatePayment < model.DateTo)))
                        .Select(rec => CreateViewModel(rec)));
                }
                else
                {
                    result.AddRange(context.Payments.Select(rec => CreateViewModel(rec)));
                }
                return result;
            }
        }

        static private PaymentViewModel CreateViewModel(Payment payment)
        {
            using (var context = new Database())
            {
                return new PaymentViewModel
                {
                    Id = payment.Id,
                    OrderId = payment.OrderId,
                    ClientId = payment.ClientId,
                    DatePayment = payment.DatePayment,
                    Sum = payment.Sum
                };
            }
        }
    }
}
