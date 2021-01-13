using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IRoomRepository
    {
        List<Rooms> GetAllRooms();
        string CreateRoom(Rooms room);
        List<Rooms> GetRoom(int hotelId);
        List<Rooms> GetRoom(string city, string pinCode, decimal price, string category);
        
    }
}
