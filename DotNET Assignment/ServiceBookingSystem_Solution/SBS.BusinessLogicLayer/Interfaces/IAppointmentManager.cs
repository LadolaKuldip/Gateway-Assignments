using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessLogicLayer.Interfaces
{
    public interface IAppointmentManager
    {
        string Create(Appointment appoinement);
        string Delete(int appointmentId);
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointments(DateTime startingDate, DateTime EndingDate);
        string Update(Appointment appointment);
        string UpdateStatus(int appointmentId, bool status);
    }
}
