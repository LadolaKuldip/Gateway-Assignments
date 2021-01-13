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
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public string CreateHotel(Hotels hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public List<Hotels> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotels GetHotel(int id)
        {
            return _hotelRepository.GetHotel(id);
        }

    }
}
