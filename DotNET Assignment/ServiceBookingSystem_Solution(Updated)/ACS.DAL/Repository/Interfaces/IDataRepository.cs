using ASC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IDataRepository
    {
        IndexCounts GetAdminIndex();
        IndexCounts GetDealerIndex(string userId);
    }
}
