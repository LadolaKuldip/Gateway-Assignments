using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IDealerManager
    {
        List<Dealer> GetDealers();
        Dealer GetDealer(int id);
        string CreateDealer(Dealer dealer);
        string EditDealer(Dealer dealer);
        string DeleteDealer(int id);
    }
}
