using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.Interfaces;
using BeautySalonBusinessLogic.ViewModel;
using BeautyShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BeautyShopDatabase.Implements
{
    public class ServiceLogic : IServiceLogic
    {
        public void CreateOrUpdate(ServiceBindingModel model)
        {
            using (var context = new Database())
            {
                Service tempService = model.Id.HasValue ? null : new Service();

                if (model.Id.HasValue)
                {
                    tempService = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
                }

                if (model.Id.HasValue)
                {
                    if (tempService == null)
                    {
                        throw new Exception("Элемент не найден");
                    }

                    CreateModel(model, tempService);
                }
                else
                {
                    context.Services.Add(CreateModel(model, tempService));
                }

                context.SaveChanges();
            }
        }

        public void Delete(ServiceBindingModel model)
        {
            using (var context = new Database())
            {
                Service element = context.Services.FirstOrDefault(rec => rec.Id == model.Id.Value);

                if (element != null)
                {
                    context.Services.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ServiceViewModel> Read(ServiceBindingModel model)
        {
            using (var context = new Database())
            {
                List<ServiceViewModel> result = new List<ServiceViewModel>();

                if (model != null)
                {
                    result.AddRange(context.Services
                        .Where(rec => rec.Id == model.Id || rec.ServiceName == model.ServiceName
                        || (model.ServiceName == null && model.Id == null))
                        .Select(rec => CreateViewModel(rec)));
                }
                else
                {
                    result.AddRange(context.Services.Select(rec => CreateViewModel(rec)));
                }
                return result;
            }
        }

        private Service CreateModel(ServiceBindingModel model, Service product)
        {
            using (var context = new Database())
            {
                product.ServiceName = model.ServiceName;
                product.Desc = model.Desc;
                product.Price = model.Price;

                return product;
            }
        }

        static private ServiceViewModel CreateViewModel(Service product)
        {
            using (var context = new Database())
            {
                return new ServiceViewModel
                {
                    Id = product.Id,
                    ServiceName = product.ServiceName,
                    Desc = product.Desc,
                    Price = product.Price,
                };
            }
        }
    }
}
