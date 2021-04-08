using ASC.Common;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IDataManager
    {
        IndexCounts GetAdminIndex();
        IndexCounts GetDealerIndex(string userId);
    }
}
