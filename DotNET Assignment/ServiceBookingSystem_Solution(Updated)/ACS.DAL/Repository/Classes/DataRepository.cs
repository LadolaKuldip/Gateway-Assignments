using ACS.DAL.Repository.Interfaces;
using ASC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Classes
{
    public class DataRepository : IDataRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public DataRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        //GET Numaric Details for Admin
        public IndexCounts GetAdminIndex()
        {
            IndexCounts indexCounts = new IndexCounts();
            indexCounts.count1 = _DbContext.Customers.Where(x => x.IsActive == true).Count();
            indexCounts.count2 = _DbContext.Vehicles.Where(x => x.IsActive == true).Count();
            indexCounts.count3 = _DbContext.Dealers.Where(x => x.IsActive == true).Count();
            indexCounts.count4 = _DbContext.ServiceBookings.Count();
            return indexCounts;
        }

        //GET Numaric Details for Dealer
        public IndexCounts GetDealerIndex(string userId)
        {
            IndexCounts indexCounts = new IndexCounts();
            indexCounts.count1 = _DbContext.Customers.Where(x => x.IsActive == true && x.Dealer.UserId== userId).Count();
            indexCounts.count2 = _DbContext.Vehicles.Where(x => x.IsActive == true && x.Customer.Dealer.UserId == userId).Count();
            indexCounts.count3 = _DbContext.Mechanics.Where(x => x.IsActive == true && x.Dealer.UserId ==  userId).Count();
            indexCounts.count4 = _DbContext.ServiceBookings.Where(x => x.Dealer.UserId == userId).Count();
            return indexCounts;
        }
    }
}
