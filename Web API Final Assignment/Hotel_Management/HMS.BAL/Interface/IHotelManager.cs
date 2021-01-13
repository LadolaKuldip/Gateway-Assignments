using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IHotelManager
    {
        List<Hotels> GetAllHotels();
        string CreateHotel(Hotels hotel);
        Hotels GetHotel(int id);
    }
}
