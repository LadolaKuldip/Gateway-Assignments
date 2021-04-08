using ASC.Entities;
using System.Collections.Generic;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrands();
        Brand GetBrand(int id);
        string CreateBrand(Brand brand);
        string EditBrand(Brand brand);
        string DeleteBrand(int id);
    }
}
