using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interfaces;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SBS.BusinessLogicLayer.Classes
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public string Create(Appointment appoinement)
        {
            return _appointmentRepository.Create(appoinement);
        }

        public string Delete(int appointmentId)
        {
            return _appointmentRepository.Delete(appointmentId);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentRepository.GetAppointments();
        }

        public IEnumerable<Appointment> GetAppointments(DateTime startingDate, DateTime EndingDate)
        {
            return _appointmentRepository.GetAppointments(startingDate, EndingDate);
        }

        public string Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }

        public string UpdateStatus(int appointmentId, bool status)
        {
            return _appointmentRepository.UpdateStatus(appointmentId, status);
        }
    }
}
