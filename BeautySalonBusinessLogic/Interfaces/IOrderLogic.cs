using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
