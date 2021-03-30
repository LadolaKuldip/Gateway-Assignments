using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Classes
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        /// <summary>
        /// Add new Department to Database
        /// </summary>
        /// <param name="department"></param>
        /// <returns>
        /// returns "created" if successfully Added
        /// returns "already" if already exists
        /// returns "null" otherwise
        /// </returns>
        public string AddDepartment(Department department)
        {
            try
            {
                if (department != null)
                {
                    var res = _dbContext.Departments.Where(x => x.Name == department.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    _dbContext.Departments.Add(department);
                    _dbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// DELETE department from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns "deleted" if successfully deleted
        /// returns "null" otherwise
        /// </returns>
        public string DeleteDepartment(int id)
        {
            var entity = _dbContext.Departments.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Departments.Remove(entity);
                _dbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        /// <summary>
        /// Edit Department in Database
        /// </summary>
        /// <param name="department"></param>
        /// <returns>
        /// returns "updated" if successfully edited
        /// returns "null" otherwise
        /// </returns>
        public string EditDepartment(Department department)
        {
            try
            {
                var entity = _dbContext.Departments.Where(x => x.Id == department.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = department.Name;

                    _dbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Get Details of department
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns single department
        /// </returns>
        public Department GetDepartment(int id)
        {
            var entity = _dbContext.Departments.Find(id);

            if (entity == null)
            {
                entity = new Department();
            }
            return entity;
        }

        /// <summary>
        /// Get All Departments List from Database
        /// </summary>
        /// <returns>
        /// returns List of Departments
        /// </returns>
        public IEnumerable<Department> GetDepartments()
        {
            var entities = _dbContext.Departments.ToList();
            return entities;
        }
    }
}
