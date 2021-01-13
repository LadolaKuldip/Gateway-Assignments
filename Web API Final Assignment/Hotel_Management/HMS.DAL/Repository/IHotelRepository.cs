using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IHotelRepository
    {
        List<Hotels> GetAllHotels();
        string CreateHotel(Hotels hotel);
        Hotels GetHotel(int id);
        //List<Hotels> GetHotel(string city, string pinCode);

    }
}
