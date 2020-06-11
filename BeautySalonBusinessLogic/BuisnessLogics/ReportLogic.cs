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

        public ReportLogic(IOrderLogic orderLogic, IPaymentLogic paymentLogic)
        {
            this.orderLogic = orderLogic;
            this.paymentLogic = paymentLogic;
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
                    if (order.Status == OrderStatus.Принят)
                    {
                        var record = new OrderViewModel
                        {
                            ClientFIO = order.ClientFIO,
                            DateCreate = order.DateCreate,
                            Sum = order.Sum,
                            Status = order.Status
                        };

                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, PaymentViewModel>> GetPayments(ReportBindingModel model)
        {

            var cl = paymentLogic.Read(new PaymentBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DatePayment.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return cl;
        }

        public List<PaymentViewModel> GetPayments(int id)
        {
            var payments = paymentLogic.Read(null);
            var list = new List<PaymentViewModel>();
            foreach (var payment in payments)
            {
                if (payment.Id == id)
                {
                    var record = new PaymentViewModel
                    {
                        DatePayment = payment.DatePayment,
                        Sum = payment.Sum
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public void SaveOrdersToExcelFile(string fileName, int id, string email)
        {
            string title = "Выполненные услуги";
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = fileName,
                Title = title,
                Orders = GetOrders(id),
            });
            SendMail(email, fileName, title);
        }

        public void SaveOrdersToWordFile(string fileName, int id, string email)
        {
            string title = "Выполненные услуги";
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                Orders = GetOrders(id),
            });
            SendMail(email, fileName, title);
        }

        public void SavePaymentsToPdfFile(string fileName, int id, string email)
        {
            string title = "Клиенты и их счета";
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = fileName,
                Title = title,
                Payments = GetPayments(id),
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
