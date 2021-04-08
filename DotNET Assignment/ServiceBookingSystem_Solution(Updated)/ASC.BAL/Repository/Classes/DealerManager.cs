using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Classes
{
    public class DealerManager : IDealerManager
    {
        private readonly IDealerRepository _dealerRepository;

        public DealerManager(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }
        public string CreateDealer(Dealer dealer)
        {
            return _dealerRepository.CreateDealer(dealer);
        }

        public string DeleteDealer(int id)
        {
            return _dealerRepository.DeleteDealer(id);
        }

        public string EditDealer(Dealer dealer)
        {
            return _dealerRepository.EditDealer(dealer);
        }

        public Dealer GetDealer(int id)
        {
            return _dealerRepository.GetDealer(id);
        }

        public List<Dealer> GetDealers()
        {
            return _dealerRepository.GetDealers();
        }
    }
}
