using SBS.DataAccessLayer.Repository.Classes;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;

namespace SBS.BusinessLogicLayer.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
            Container.RegisterType<ISupportRepository, SupportRepository>();
            Container.RegisterType<IAppointmentRepository, AppointmentRepository>();
        }
    }
}
