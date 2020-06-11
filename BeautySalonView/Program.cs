using BeautySalonBusinessLogic.Interfaces;
using BeautySalonDatabase.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace BeautySalonView
{
    static class Program
    {
        public static bool isLogined;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var login = new FormAuthentication();
            login.ShowDialog();

            if (isLogined)
            {
                Application.Run(container.Resolve<FormMain>());
            }
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceLogic, ServiceLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPaymentLogic, PaymentLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
