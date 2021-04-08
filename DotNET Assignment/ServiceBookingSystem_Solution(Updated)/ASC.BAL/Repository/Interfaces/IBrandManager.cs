using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IBrandManager
    {
        IEnumerable<Brand> GetBrands();
        Brand GetBrand(int id);
        string CreateBrand(Brand brand);
        string EditBrand(Brand brand);
        string DeleteBrand(int id);
    }
}
