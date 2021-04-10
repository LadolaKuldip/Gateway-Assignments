using BAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ViewLayer.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentsController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        // GET: Departments
        public IActionResult Index()
        {
            var departments = _departmentManager.GetDepartments();
            return View(departments);
        }

        // GET: Departments/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _departmentManager.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            return PartialView(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                string response = _departmentManager.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return PartialView(department);
        }

        // GET: Departments/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _departmentManager.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return PartialView(department);
        }

        // POST: Departments/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([Bind("Id,Name")] Department department)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    string reponse = _departmentManager.EditDepartment(department);
                }
                catch (Exception)
                {
                        return NotFound();                    
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(department);
        }

        // GET: Departments/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var department = _departmentManager.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return PartialView(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string reponse = _departmentManager.DeleteDepartment(id);

            return RedirectToAction(nameof(Index));
        }
        /*
        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }*/
    }
}
