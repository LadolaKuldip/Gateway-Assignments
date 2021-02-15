using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        public AppointmentRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        public string Create(Appointment appoinement)
        {
            try
            {
                if (appoinement != null)
                {
                    var res = _dbContext.Appointments.Where(x => x.VehicleId == appoinement.VehicleId && x.ServiceId == appoinement.ServiceId).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Appointment entity = new Database.Appointment();

                    entity = AutoMapperConfig.AppointmentToDbAppointmentMapper.Map<Database.Appointment>(appoinement);

                    _dbContext.Appointments.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }

        public string Delete(int appointmentId)
        {
            try
            {
                Database.Appointment appointment = _dbContext.Appointments
                    .Where(x => x.Id == appointmentId).FirstOrDefault();
                if (appointment != null)
                {
                    _dbContext.Appointments.Remove(appointment);
                    _dbContext.SaveChanges();
                    return "deleted";
                }
                return "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            List<Appointment> appointmentsReturn = new List<Appointment>();
            var appointments = _dbContext.Appointments.ToList();
            if (appointments.Any())
            {
                foreach (var appointment in appointments)
                {
                    Appointment entity = new Appointment();
                    entity = AutoMapperConfig.DbAppointmentToAppointmentMapper.Map<Appointment>(appointment);

                    appointmentsReturn.Add(entity);
                }
                return appointmentsReturn;
            }
            return new List<Appointment>();
        }

        public IEnumerable<Appointment> GetAppointments(DateTime startingDate, DateTime EndingDate)
        {
            List<Appointment> appointmentsReturn = new List<Appointment>();
            var appointments = _dbContext.Appointments
                .Where(x => x.AppointmentDate >= startingDate && x.AppointmentDate <= EndingDate).ToList();
            if (appointments.Any())
            {
                foreach (var appointment in appointments)
                {
                    Appointment entity = new Appointment();
                    entity = AutoMapperConfig.DbAppointmentToAppointmentMapper.Map<Appointment>(appointment);

                    appointmentsReturn.Add(entity);
                }
                return appointmentsReturn;
            }
            return new List<Appointment>();
        }

        public string Update(Appointment appointment)
        {
            try
            {
                var entity = _dbContext.Appointments
                    .Where(x => x.Id == appointment.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.MechanicId = appointment.MechanicId;
                    entity.ServiceId = appointment.ServiceId;
                    entity.VehicleId = appointment.VehicleId;
                    entity.CustomerId = appointment.CustomerId;
                    entity.DealerId = appointment.DealerId;
                    entity.Status = appointment.Status;
                    entity.AppointmentDate = appointment.AppointmentDate;

                    _dbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }

        public string UpdateStatus(int appointmentId, bool status)
        {
            try
            {
                Database.Appointment appointment = _dbContext.Appointments
                    .Where(x => x.Id == appointmentId).FirstOrDefault();
                if (appointment != null)
                {
                    if (status == true)
                    {
                        appointment.Status = 1;
                        return "updated";
                    }
                    else
                    {
                        appointment.Status = -1;
                        return "updated";
                    }
                }
                return "null";

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }
    }
}
