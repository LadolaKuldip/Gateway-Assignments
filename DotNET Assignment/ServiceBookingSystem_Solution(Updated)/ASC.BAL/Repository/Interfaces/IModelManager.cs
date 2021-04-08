using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IModelManager
    {
        IEnumerable<Model> GetModels();
        IEnumerable<Model> GetbyBrand(int id);
        Model GetModel(int id);
        string CreateModel(Model model);
        string EditModel(Model model);
        string DeleteModel(int id);
    }
}
