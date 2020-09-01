using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
using BeautySalonBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using BeautySalonBusinessLogic.BindingModels;
using System.Linq;
using BeautySalonBusinessLogic.HelperModels;
using System.Net.Mail;
using System.Net;

namespace BeautySalonBusinessLogic.BuisnessLogics
{
    public class ReportLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IPaymentLogic paymentLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly IClientLogic clientLogic;

        public ReportLogic(IOrderLogic orderLogic, IPaymentLogic paymentLogic,
            IServiceLogic serviceLogic, IClientLogic clientLogic)
        {
            this.orderLogic = orderLogic;
            this.paymentLogic = paymentLogic;
            this.serviceLogic = serviceLogic;
            this.clientLogic = clientLogic;
        }

        public List<OrderViewModel> GetOrders()
        {
            var orders = orderLogic.Read(null);
            var list = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                if (order.Status == OrderStatus.Принят)
                {
                    var record = new OrderViewModel
                    {
                        ClientFIO = order.ClientFIO,
                        DateCreate = order.DateCreate,
                        Sum = order.Sum,
                        Price = order.Price,
                        Status = order.Status
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<OrderViewModel> GetOrders(int id)
        {
            var orders = orderLogic.Read(null);
            var list = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                if (order.Id == id)
                {
                    if (order.Status != OrderStatus.Оплачен)
                    {
                        var record = new OrderViewModel
                        {
                            ClientFIO = order.ClientFIO,
                            DateCreate = order.DateCreate,
                            Sum = order.Sum,
                            Price = order.Price,
                            Status = order.Status
                        };

                        list.Add(record);
                    }
                }
            }
            return list;
        }

        public Dictionary<int, List<PaymentViewModel>> GetOrders(OrderBindingModel model)
        {
            var orders = orderLogic.Read(model).ToList();
            Dictionary<int, List<PaymentViewModel>> payments = new Dictionary<int, List<PaymentViewModel>>();
            foreach (var order in orders)
            {
                var orderPayments = paymentLogic.Read(new PaymentBindingModel { OrderId = order.Id }).ToList();
                payments.Add(order.Id, orderPayments);
            }
            return payments;
        }

        public List<ServiceViewModel> GetOrderServices(OrderViewModel order)
        {
            var services = new List<ServiceViewModel>();

            foreach (var service in order.OrderServices)
            {
                services.Add(serviceLogic.Read(new ServiceBindingModel
                {
                    Id = service.ServiceId
                }).FirstOrDefault());

            }
            return services;
        }

        public List<ReportViewModel> GetPayments(ReportBindingModel model)
        {
            var cl = paymentLogic.Read(new PaymentBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
            });
            List<ReportViewModel> rm = new List<ReportViewModel>();
            foreach(var payment in cl)
            {
                string clientFIO = clientLogic.Read(new ClientBindingModel { Id = payment.ClientId })
                            .FirstOrDefault(rec => rec.Id == payment.ClientId).ClientFIO;
                rm.Add(new ReportViewModel
                {
                    ClientFIO = clientFIO,
                    DatePayment = payment.DatePayment,
                    OrderId = payment.OrderId,
                    Sum = payment.Sum
                });
            }
            return rm;
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            string title = "Заказы";
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = title,
                Orders = GetOrders(model.id),
            });
            SendMail(model.email, model.FileName, title);
        }

        public void SaveOrdersToWordFile(ReportBindingModel model)
        {
            string title = "Заказы";
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = title,
                Orders = GetOrders(model.id),
            });
            SendMail(model.email, model.FileName, title);
        }

        public void SaveOrderServicesToWordFile(string fileName, OrderViewModel order, string email)
        {
            string title = "Список услуг по заказу №" + order.Id;
            SaveToWord.CreateDoc(new WordInfoClient
            {
                FileName = fileName,
                Title = title,
                Services = GetOrderServices(order)
            });
            SendMail(email, fileName, title);
        }

        public void SavePaymentsToPdfFile(ReportBindingModel model)
        {
            string title = "Клиенты и их платежи";
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = title,
                Payments = GetPayments(model)
            });
        }

        public void SaveOrdersToPdfFile(string fileName, OrderBindingModel order, string email)
        {
            string title = " Просмотр заказанных услуг в период с " + order.DateFrom.ToString() + " по " + order.DateTo.ToString();
            SaveToPdf.CreateDoc(new PdfInfoClient
            {
                FileName = fileName,
                Title = title,
                Orders = orderLogic.Read(order).ToList(),
                Payments = GetOrders(order)
            });
            SendMail(email, fileName, title);
        }
        public void SaveOrderServicesToExcelFile(string fileName, OrderViewModel order, string email)
        {
            string title = "Список услуг по заказу №" + order.Id;
            SaveToExcel.CreateDoc(new ExcelInfoClient
            {
                FileName = fileName,
                Title = title,
                Services = GetOrderServices(order)
            });
            SendMail(email, fileName, title);
        }
        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("BeautySalonTestOrg@gmail.com", "Салон красоты <Вы ужасны>");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("BeautySalonTestOrg@gmail.com", "qwerty123456-");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}