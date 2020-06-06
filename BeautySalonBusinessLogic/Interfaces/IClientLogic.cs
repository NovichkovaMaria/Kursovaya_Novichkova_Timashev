using System;
using System.Collections.Generic;
using System.Text;
using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.ViewModel;

namespace BeautySalonBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
