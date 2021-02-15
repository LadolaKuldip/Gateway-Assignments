using System.Web.Http;
using Unity;
using Unity.WebApi;
using SBS.BusinessLogicLayer.Interfaces;
using SBS.BusinessLogicLayer.Classes;
using SBS.BusinessLogicLayer.Helper;

namespace ServiceBookingSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IVenicleManager, VehicleManager>();
            container.RegisterType<ISupportManager, SupportManager>();
            container.RegisterType<IAppointmentManager, AppointmentManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}