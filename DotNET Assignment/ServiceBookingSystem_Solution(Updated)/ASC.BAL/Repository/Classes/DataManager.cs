using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Common;
using System;

namespace ASC.BAL.Repository.Classes
{
    public class DataManager : IDataManager
    {
        private readonly IDataRepository _dataRepository;

        public DataManager(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public IndexCounts GetAdminIndex()
        {
            return _dataRepository.GetAdminIndex();
        }

        public IndexCounts GetDealerIndex(string userId)
        {
            return _dataRepository.GetDealerIndex(userId);
        }
    }
}
