﻿using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.DAL.Repository.Classes
{
    public class ModelRepository : IModelRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public ModelRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        //CREATE Model in DATABASE
        public string CreateModel(Model model)
        {
            try
            {
                if (model != null)
                {
                    var res = _DbContext.Models.Where(x => x.Name == model.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Model entity = new Database.Model();
                    entity = AutoMapperConfig.ModelMapper.Map<Database.Model>(model);

                    _DbContext.Models.Add(entity);
                    _DbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //SOFT DELETE Model from DATABASE
        public string DeleteModel(int id)
        {
            var entity = _DbContext.Models.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                if (entity.IsActive == true)
                {
                    entity.IsActive = false;
                }
                else
                {
                    entity.IsActive = true;
                }
                _DbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        //EDIT Model in DATABASE
        public string EditModel(Model model)
        {
            try
            {
                var entity = _DbContext.Models.Where(x => x.Id == model.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.IsActive = model.IsActive;
                    entity.BrandId = model.BrandId;

                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //GET all Models of Brand
        public IEnumerable<Model> GetbyBrand(int id)
        {
            List<Model> models = new List<Model>();
            IEnumerable<Database.Model> entities = _DbContext.Models.Include("Brand").Where(x => x.BrandId == id).ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Model model = new Model();
                    model = AutoMapperConfig.ModelMapper.Map<Model>(item);
                    models.Add(model);
                }
            }
            return models;
        }

        //GET single Model By Id
        public Model GetModel(int id)
        {
            Model model;
            Database.Model entity = _DbContext.Models.Find(id);

            if (entity != null)
            {
                model = AutoMapperConfig.ModelMapper.Map<Model>(entity);
            }
            else
            {
                model = new Model();
            }
            return model;
        }

        //GET all Models
        public IEnumerable<Model> GetModels()
        {
            List<Model> models = new List<Model>();
            IEnumerable<Database.Model> entities = _DbContext.Models.Include("Brand").ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Model model = new Model();
                    model = AutoMapperConfig.ModelMapper.Map<Model>(item);
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
