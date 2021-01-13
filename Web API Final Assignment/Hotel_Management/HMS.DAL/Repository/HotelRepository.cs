using AutoMapper;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelManagementDBEntities _dbContext;
        
        public HotelRepository()
        {
            _dbContext = new Database.HotelManagementDBEntities();
        }
        public string CreateHotel(Hotels hotel)
        {
            try
            {
                if (hotel != null)
                {
                    Database.Hotel entity = new Database.Hotel();

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Hotels, Database.Hotel>());
                    var mapper = new Mapper(config);

                    entity = mapper.Map<Database.Hotel>(hotel);
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;

                    _dbContext.Hotels.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotels> GetAllHotels()
        {
            var entities = _dbContext.Hotels.OrderBy(x => x.Name).ToList();

            List<Hotels> hotels = new List<Hotels>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Hotel, Hotels>());
            var mapper = new Mapper(config);

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Hotels hotel = new Hotels();
                    hotel = mapper.Map<Hotels>(item);
                    hotels.Add(hotel);
                }
            }
            return hotels;
        }

        public Hotels GetHotel(int id)
        {
            var entity = _dbContext.Hotels.Where(x => x.Id == id).FirstOrDefault();

            Hotels hotel = new Hotels();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Hotel, Hotels>());
            var mapper = new Mapper(config);

            if (entity != null)
            {
                hotel = mapper.Map<Hotels>(entity);
            }
            return hotel;
        }

        /*public List<Hotels> GetHotel(string city, string pinCode)
        {
            var entities = _dbContext.Hotels.Where(x => x.City.Equals(city) && x.PinCode.Equals(pinCode)).ToList();

            List<Hotels> hotels = new List<Hotels>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Hotel, Hotels>());
            var mapper = new Mapper(config);

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Hotels hotel = new Hotels();
                    hotel = mapper.Map<Hotels>(item);
                    hotels.Add(hotel);
                }
            }
            return hotels;
        }*/
    }
}
