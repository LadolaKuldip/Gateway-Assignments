using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Classes
{
    public class ModelManager : IModelManager
    {
        private readonly IModelRepository _modelRepository;

        public ModelManager(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public string CreateModel(Model model)
        {
            return _modelRepository.CreateModel(model);
        }

        public string DeleteModel(int id)
        {
            return _modelRepository.DeleteModel(id);
        }

        public string EditModel(Model model)
        {
            return _modelRepository.EditModel(model);
        }

        public IEnumerable<Model> GetbyBrand(int id)
        {
            return _modelRepository.GetbyBrand(id);
        }

        public Model GetModel(int id)
        {
            return _modelRepository.GetModel(id);
        }

        public IEnumerable<Model> GetModels()
        {
            return _modelRepository.GetModels();
        }
    }
}
