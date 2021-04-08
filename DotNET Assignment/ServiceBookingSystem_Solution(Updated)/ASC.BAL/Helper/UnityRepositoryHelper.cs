using ACS.DAL.Repository.Classes;
using ACS.DAL.Repository.Interfaces;
using Unity.Extension;
using Unity;

namespace ASC.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IBrandRepository, BrandRepository>();
            Container.RegisterType<IModelRepository, ModelRepository>();
            Container.RegisterType<IServiceRepository, ServiceRepository>();
            Container.RegisterType<IDealerRepository, DealerRepository>();
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
            Container.RegisterType<IMechanicRepository, MechanicRepository>();
            Container.RegisterType<IDataRepository, DataRepository>();
            Container.RegisterType<IServiceBookingRepository, ServiceBookingRepository>();
        }
    }
}
