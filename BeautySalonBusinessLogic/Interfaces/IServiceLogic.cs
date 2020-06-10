using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.Interfaces
{
    public interface IServiceLogic
    {
        List<ServiceViewModel> Read(ServiceBindingModel model);
        void CreateOrUpdate(ServiceBindingModel model);
        void Delete(ServiceBindingModel model);
    }
}
