using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public string CreateRoom(Rooms room)
        {
            return _roomRepository.CreateRoom(room);
        }

        public List<Rooms> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public List<Rooms> GetRoom(int hotelId)
        {
            return _roomRepository.GetRoom(hotelId);
        }

        public List<Rooms> GetRoom(string city, string pinCode, decimal price, string category)
        {
            return _roomRepository.GetRoom(city, pinCode, price, category);
        }
    }
}
