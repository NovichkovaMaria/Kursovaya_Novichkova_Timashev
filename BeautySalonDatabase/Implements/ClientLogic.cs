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
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new Database())
            {
                Client element = model.Id.HasValue ? null : new Client();
                if (model.Id.HasValue)
                {
                    element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Client();
                    context.Clients.Add(element);
                }
                element.Email = model.Email == null ? element.Email : model.Email;
                element.Login = model.Login == null ? element.Login : model.Login;
                element.ClientFIO = model.ClientFIO == null ? element.ClientFIO : model.ClientFIO;
                element.Phone = model.Phone == null ? element.Phone : model.Phone;
                element.isBlocked = model.isBlocked == null ? element.isBlocked : model.isBlocked;
                element.Password = model.Password == null ? element.Password : model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new Database())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Clients
                 .Where(rec => model == null
                   || rec.Id == model.Id
                 || (rec.Login == model.Login || rec.Email == model.Email)
                        && (model.Password == null || rec.Password == model.Password))
               .Select(rec => new ClientViewModel
               {
                   Id = rec.Id,
                   Login = rec.Login,
                   ClientFIO = rec.ClientFIO,
                   Email = rec.Email,
                   Password = rec.Password,
                   Phone = rec.Phone,
                   isBlocked = rec.isBlocked
               })
                .ToList();
            }
        }
    }
}
