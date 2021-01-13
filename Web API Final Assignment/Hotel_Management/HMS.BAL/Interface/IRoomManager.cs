using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IRoomManager
    {
        List<Rooms> GetAllRooms();
        string CreateRoom(Rooms room);
        List<Rooms> GetRoom(int hotelId);
        List<Rooms> GetRoom(string city, string pinCode, decimal price, string category);
    }
}
