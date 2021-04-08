using ASC.Entities;
using System.Collections.Generic;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IDealerRepository
    {
        List<Dealer> GetDealers(); 
        Dealer GetDealer(int id);
        string CreateDealer(Dealer dealer);
        string EditDealer(Dealer dealer);
        string DeleteDealer(int id);
    }
}
