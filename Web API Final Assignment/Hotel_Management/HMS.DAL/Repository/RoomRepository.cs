using AutoMapper;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Database.HotelManagementDBEntities _dbContext;

        public RoomRepository()
        {
            _dbContext = new Database.HotelManagementDBEntities();
        }

        public string CreateRoom(Rooms room)
        {
            try
            {
                if (room != null)
                {
                    Database.Room entity = new Database.Room();

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Rooms, Database.Room>());
                    var mapper = new Mapper(config);

                    entity = mapper.Map<Database.Room>(room);
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;

                    _dbContext.Rooms.Add(entity);
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

        public List<Rooms> GetAllRooms()
        {
            var entities = _dbContext.Rooms.OrderBy(x => x.Price).ToList();

            List<Rooms> rooms = new List<Rooms>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Room, Rooms>());
            var mapper = new Mapper(config);

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Rooms room = new Rooms();
                    room = mapper.Map<Rooms>(item);
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Rooms> GetRoom(int hotelId)
        {
            var entities = _dbContext.Rooms.Where(x => x.HotelId == hotelId).OrderBy(x => x.Price).ToList();

            List<Rooms> rooms = new List<Rooms>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Room, Rooms>());
            var mapper = new Mapper(config);

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Rooms room = new Rooms();
                    room = mapper.Map<Rooms>(item);
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Rooms> GetRoom(string city, string pinCode, decimal price, string category)
        {
            var entities = _dbContext.Rooms.Where(x => x.Hotel.City.Equals(city) && x.Hotel.PinCode.Equals(pinCode) && x.Price <= price && x.Category.Equals(category)).OrderBy(x => x.Price).ToList();

            List<Rooms> rooms = new List<Rooms>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.Room, Rooms>());
            var mapper = new Mapper(config);

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Rooms room = new Rooms();
                    room = mapper.Map<Rooms>(item);
                    rooms.Add(room);
                }
            }
            return rooms;
        }

    }
}
