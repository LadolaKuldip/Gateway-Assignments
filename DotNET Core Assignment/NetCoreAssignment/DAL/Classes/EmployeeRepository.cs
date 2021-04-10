using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        /// <summary>
        /// Add new Employee to Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>
        /// returns "created" if successfully Added
        /// returns "already" if employee already exists
        /// returns "null" otherwise
        /// </returns>
        public string AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var res = _dbContext.Employees.Where(x => x.Name == employee.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    _dbContext.Employees.Add(employee);
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
        /// DELETE Employee from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns "deleted" if successfully deleted
        /// returns "null" otherwise
        /// </returns>
        public string DeleteEmployee(int id)
        {
            var entity = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Employees.Remove(entity);
                _dbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        /// <summary>
        /// Edit Employee in Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>
        /// returns "updated" if successfully edited
        /// returns "null" otherwise
        /// </returns>
        public string EditEmployee(Employee employee)
        {
            try
            {
                var entity = _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = employee.Name;
                    entity.DepartmentId = employee.DepartmentId;
                    entity.Email = employee.Email;
                    entity.IsManager = employee.IsManager;
                    entity.Phone = employee.Phone;
                    entity.Salary = employee.Salary;
                    entity.Manager = employee.Manager;
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
        /// Get Details of Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns single Employee
        /// </returns>
        public Employee GetEmployee(int id)
        {
            var entity = _dbContext.Employees.Include(d => d.Department).Where(d => d.Id == id).FirstOrDefault();

            if (entity == null)
            {
                entity = new Employee();
            }
            return entity;
        }

        /// <summary>
        /// Get All Employees List from Database
        /// </summary>
        /// <returns>
        /// returns List of Employees
        /// </returns>
        public IEnumerable<Employee> GetEmployees()
        {
            var entities = _dbContext.Employees.Include(d =>d.Department).ToList();
            return entities;
        }

        /// <summary>
        /// Get All Employees who is Manager List from Database
        /// </summary>
        /// <returns>
        /// returns List of Managerss
        /// </returns>
        public IEnumerable<Employee> GetManagers()
        {
            var entities = _dbContext.Employees.Where(e => e.IsManager == true).ToList();
            return entities;
        }
    }
}
