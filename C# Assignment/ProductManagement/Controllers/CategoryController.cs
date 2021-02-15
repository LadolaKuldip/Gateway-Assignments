using log4net;
using Microsoft.AspNet.Identity;
using ProductManagement.ExceptionHandler;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    [UserExceptionHandler]
    public class CategoryController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [Authorize]
        // GET: Category/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        [Authorize]
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();

                    TempData["Type"] = "0";
                    TempData["Message"] = "Category Created Successfully   Category :" + category.Name;

                    string UserId = User.Identity.GetUserId();
                    Log.Info("Category Created with Name(" + category.Name + ") by User [ " + UserId + " ]");

                    return RedirectToAction("Index");
                }
                Category viewCat = category;
                return View(viewCat);
            }
            catch
            {
                throw;
            }
        }

        [Authorize]
        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
                return HttpNotFound();

            return PartialView(category);
        }

        [Authorize]
        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                var categoryInDb = _context.Categories.Single(c => c.Id == category.Id);

                categoryInDb.Name = category.Name;

                _context.SaveChanges();

                TempData["Type"] = "1";
                TempData["Message"] = "Category Edited Successfully   Category :" + category.Name;

                string UserId = User.Identity.GetUserId();
                Log.Info("Category Edited with Id(" + category.Id + ") by User [ " + UserId + " ]");

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        [Authorize]
        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Category category = _context.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                var products = _context.Products.Where(p => p.CategoryId == category.Id).ToList();
                if (products.Count == 0)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();

                    TempData["Type"] = "2";
                    TempData["Message"] = "Category Removed Successfully   Probuct :" + category.Name;

                    string UserId = User.Identity.GetUserId();
                    Log.Info("Category Deleted with Id(" + category.Id + ") by User [ " + UserId + " ]");

                    return RedirectToAction("Index");
                }

                TempData["Type"] = "3";
                TempData["Message"] = "Can Not Remove Category bcz some Products available with   Category :" + category.Name;
                                
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

    }
}
