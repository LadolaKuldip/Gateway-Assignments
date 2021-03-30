using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities;
using BAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ViewLayer.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        public EmployeesController(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }


        // GET: Employees
        public IActionResult Index()
        {
            var employees = _employeeManager.GetEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _employeeManager.GetEmployee(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            var departments = _departmentManager.GetDepartments();
            var managers = _employeeManager.GetManagers();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name");
            ViewData["Manager"] = new SelectList(managers, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Salary,IsManager,Manager,Phone,Email,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                string response = _employeeManager.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentManager.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            var managers = _employeeManager.GetManagers();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name", employee.Manager);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            var departments = _departmentManager.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            var managers = _employeeManager.GetManagers();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name", employee.Manager);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Salary,IsManager,Manager,Phone,Email,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string reponse = _employeeManager.EditEmployee(employee);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentManager.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            var managers = _employeeManager.GetManagers();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name", employee.Manager);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string reponse = _employeeManager.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }
        /*
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }*/
    }
}
