using BeautySalonBusinessLogic.BindingModels;
using BeautySalonBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.Interfaces
{
    public interface IPaymentLogic
    {
        List<PaymentViewModel> Read(PaymentBindingModel model);
        void CreateOrUpdate(PaymentBindingModel model);
        void Delete(PaymentBindingModel model);
    }
}
