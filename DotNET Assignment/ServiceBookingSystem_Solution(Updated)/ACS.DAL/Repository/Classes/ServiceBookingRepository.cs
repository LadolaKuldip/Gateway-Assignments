using ACS.DAL.Repository.Interfaces;
using ASC.Common;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace ACS.DAL.Repository.Classes
{
    public class ServiceBookingRepository : IServiceBookingRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public ServiceBookingRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        //CREATE ServiceBooking in DATABASE
        public string AddBooking(ServiceBookingModel serviceBookingModel)
        {
            try
            {
                if (serviceBookingModel.ServiceBooking != null)
                {
                    var res = _DbContext.ServiceBookings.Where(x => x.VehicleId == serviceBookingModel.ServiceBooking.VehicleId
                    && x.BookingDate == serviceBookingModel.ServiceBooking.BookingDate).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.ServiceBooking entity = new Database.ServiceBooking();
                    entity = AutoMapperConfig.ServiceBookingMapper.Map<Database.ServiceBooking>(serviceBookingModel.ServiceBooking);
                    entity.Status = "Pending";
                    _DbContext.ServiceBookings.Add(entity);
                    _DbContext.SaveChanges();
                    int id = entity.Id;
                    double totalAmmount = 0;
                    string htmlContentService = "";
                    foreach (var I in serviceBookingModel.servicesIds)
                    {
                        Database.Service service = _DbContext.Services.Find(I);
                        Database.SelectedService selectedService = new Database.SelectedService();
                        selectedService.ServiceBookingId = entity.Id;
                        selectedService.ServiceId = service.Id;
                        _DbContext.SelectedServices.Add(selectedService);
                        _DbContext.SaveChanges();

                        totalAmmount += service.Amount;

                        htmlContentService += "<tr><td>" + service.Name + "</td><td>&nbsp;</td><td>" + service.Amount + "</td></tr>";
                    }

                    entity.TotalAmmount = totalAmmount;
                    _DbContext.SaveChanges();

                    //Send mail of Appointment Booking to User

                    string FilePath = "D:/Projects/BookinMail.html";
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();

                    Database.Dealer dealer = _DbContext.Dealers.Find(entity.DealerId);
                    Database.Vehicle vehicle = _DbContext.Vehicles.Where(x => x.Id == entity.VehicleId).FirstOrDefault();
                    Database.Customer customer = _DbContext.Customers.Where(x => x.Id == vehicle.CustomerId).FirstOrDefault();
                    DateTime time = DateTime.Now;

                    MailText = MailText.Replace("{NumberPlate}", vehicle.NumberPlate);
                    MailText = MailText.Replace("{BookingDate}", entity.BookingDate.ToString());
                    MailText = MailText.Replace("{BookingTime}", time.ToString("t"));
                    MailText = MailText.Replace("{PickupAddress}", entity.PickupAddress);
                    MailText = MailText.Replace("{DropAddress}", entity.DropAddress);
                    MailText = MailText.Replace("{Dealer}", dealer.Name);
                    MailText = MailText.Replace("{PhoneNumber}", dealer.PhoneNumber);
                    MailText = MailText.Replace("{Service}", htmlContentService);
                    MailText = MailText.Replace("{Total}", totalAmmount.ToString());
                    str.Close();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(customer.Email);
                    mail.From = new MailAddress("automobile.onthego@gmail.com");
                    mail.Subject = "Appontment Booked";
                    string Body = MailText;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("automobile.onthego@gmail.com", "Password@123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);


                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Edit ServiceBooking in DATABASE
        public string EditBooking(ServiceBooking serviceBooking)
        {
            try
            {
                var entity = _DbContext.ServiceBookings.Where(x => x.Id == serviceBooking.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.BookingDate = serviceBooking.BookingDate;
                    entity.ReturnDate = serviceBooking.ReturnDate;
                    entity.TotalAmmount = serviceBooking.TotalAmmount;
                    entity.Status = serviceBooking.Status;
                    entity.DropAddress   = serviceBooking.DropAddress;
                    entity.PickupAddress = serviceBooking.PickupAddress;
                    entity.MechanicId = serviceBooking.MechanicId;
                    entity.VehicleId = serviceBooking.VehicleId;
                    entity.DealerId = serviceBooking.DealerId;
                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditFeedback(ServiceBooking serviceBooking)
        {
            try
            {
                var entity = _DbContext.ServiceBookings.Where(x => x.Id == serviceBooking.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Feedback = serviceBooking.Feedback;
                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditPay(ServiceBooking serviceBooking)
        {
            try
            {
                var entity = _DbContext.ServiceBookings.Where(x => x.Id == serviceBooking.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.PayDone = serviceBooking.PayDone;
                    entity.PayMethod = serviceBooking.PayMethod;
                    entity.PayId = serviceBooking.PayId;
                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ServiceBookingEditModel GetBooking(int id)
        {
            ServiceBooking serviceBooking;
            List<Mechanic> mechanics = new List<Mechanic>();

            Database.ServiceBooking entity = _DbContext.ServiceBookings.Include("Dealer").Include("Vehicle").Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                serviceBooking = AutoMapperConfig.ServiceBookingMapper.Map<ServiceBooking>(entity);

                IEnumerable<Database.Mechanic> entities = _DbContext.Mechanics.Where(x => x.DealerId == entity.DealerId).ToList();
                foreach (var item in entities)
                {
                    Mechanic mechanic = AutoMapperConfig.MechanicMapper.Map<Mechanic>(item);
                    mechanics.Add(mechanic);
                }
            }
            else
            {
                serviceBooking = null;
                mechanics = null;
            }
            ServiceBookingEditModel model = new ServiceBookingEditModel
            {
                ServiceBooking = serviceBooking,
                mechanics = mechanics
            };
            return model;
        }

        //GET all ServiceBookings
        public IEnumerable<ServiceBooking> GetBookings()
        {
            List<ServiceBooking> serviceBookings = new List<ServiceBooking>();
            IEnumerable<Database.ServiceBooking> entities = _DbContext.ServiceBookings.Include("Dealer").Include("Vehicle").ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    ServiceBooking serviceBooking = new ServiceBooking();
                    serviceBooking = AutoMapperConfig.ServiceBookingMapper.Map<ServiceBooking>(item);
                    serviceBookings.Add(serviceBooking);
                }
            }
            return serviceBookings;
        }

        //GET all ServiceBookings of Dealer
        public IEnumerable<ServiceBooking> GetDealerBookings(string userId)
        {
            List<ServiceBooking> serviceBookings = new List<ServiceBooking>();
            IEnumerable<Database.ServiceBooking> entities = _DbContext.ServiceBookings.Include("Dealer").Include("Vehicle").Where(x => x.Dealer.UserId == userId).ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    ServiceBooking serviceBooking = new ServiceBooking();
                    serviceBooking = AutoMapperConfig.ServiceBookingMapper.Map<ServiceBooking>(item);
                    serviceBookings.Add(serviceBooking);
                }
            }
            return serviceBookings;
        }

        //GET single ServiceBooking Details By Id
        public ServiceBookingDetailModel GetDetail(int id)
        {
            ServiceBooking serviceBooking;
            List<Service> services = new List<Service>();
            Database.ServiceBooking entity = _DbContext.ServiceBookings.Include("Dealer").Include("Vehicle").Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                serviceBooking = AutoMapperConfig.ServiceBookingMapper.Map<ServiceBooking>(entity);

                IEnumerable<Database.SelectedService> entities = _DbContext.SelectedServices.Where(x => x.ServiceBookingId == entity.Id).ToList();
                foreach (var item in entities)
                {
                    Service service = AutoMapperConfig.ServiceMapper.Map<Service>(item.Service);
                    services.Add(service);
                }
            }
            else
            {
                serviceBooking = null;
                services = null;
            }
            ServiceBookingDetailModel model = new ServiceBookingDetailModel
            {
                ServiceBooking = serviceBooking,
                Services = services
            };
            return model;
        }

        //GET all ServiceBookings of User
        public IEnumerable<ServiceBooking> GetUserBookings(string userId)
        {
            List<ServiceBooking> serviceBookings = new List<ServiceBooking>();
            IEnumerable<Database.ServiceBooking> entities = _DbContext.ServiceBookings.Include("Dealer").Include("Vehicle").Where(x => x.Vehicle.Customer.UserId == userId).ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    ServiceBooking serviceBooking = new ServiceBooking();
                    serviceBooking = AutoMapperConfig.ServiceBookingMapper.Map<ServiceBooking>(item);
                    serviceBookings.Add(serviceBooking);
                }
            }
            return serviceBookings;
        }
    }
}
