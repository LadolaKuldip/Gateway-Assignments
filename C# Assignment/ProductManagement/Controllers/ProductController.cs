using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using ProductManagement.Models;
using System.IO;
using PagedList;
using ProductManagement.ExceptionHandler;
using Microsoft.AspNet.Identity;
using log4net;
using System.Net.Http;

namespace ProductManagement.Controllers
{
    //Assigning User Exception Handeler to class
    [UserExceptionHandler]
    public class ProductController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        private readonly ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //If User Haven't Logged in ,Then he can only see the list of Products

        // GET: Product
        public ActionResult Index(string sortOrder, string searchData, string option, string filterValue, int? pageNumber)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.Option = option;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "Category_desc" : "Category";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";

            if (searchData != null)
                pageNumber = 1;
            else
                searchData = filterValue;

            ViewBag.SearchData = searchData;

            var products = from p in _context.Products select p;

            //Searching data from database according to parameter
            if (!String.IsNullOrEmpty(searchData))
            {
                if (option == "Name")
                    products = products.Where(s => s.Name.ToUpper().Contains(searchData.ToUpper()));
                else if (option == "Category")
                    products = products.Where(s => s.Category.Name.ToUpper().Contains(searchData.ToUpper()));
                else
                    products = products.Where(s => s.Price.ToString().Contains(searchData));
            }

            //Sorting data from database according to parameter
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Category":
                    products = products.OrderBy(p => p.Category.Name);
                    break;
                case "Category_desc":
                    products = products.OrderByDescending(p => p.Category.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "Price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }
            int Size_Of_Page = 2;
            int No_Of_Page = (pageNumber ?? 1);

            //Ckeck whether user logged in or not??
            string UserId = User.Identity.GetUserId();

            //Adding Log to File and Database
            if (!string.IsNullOrEmpty(UserId))
            {
                Log.Info("Product List Page Visited by User [ " + UserId + " ]");
            }
            else
            {
                Log.Info("Product List Page Visited by Anonymous User");
            }

            return View(products.Include(p => p.Category).ToList().ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [Authorize]
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            //Callig WebApi ProductsController ( GET: api/Products/5 ) Method
            HttpResponseMessage responseMessage = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
            Product product = responseMessage.Content.ReadAsAsync<Product>().Result;

            if (product == null)
                return HttpNotFound();

            //Adding Log to File and Database
            string UserId = User.Identity.GetUserId();
            Log.Info("Product Details(" + id + ") Page Visited by User [ " + UserId + " ]");
            
            return View(product);
        }

        [Authorize]
        // GET: Product/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Product = new Product(),
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);

        }

        [Authorize]
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create (Product product)
        {
            try
            {
                //Check for Small Image Validation if present
                if (product.SmallImageFile != null && product.SmallImageFile.ContentLength > 0)
                {
                    if (product.SmallImageFile.ContentLength > 2*1024*1024)
                    {
                        ModelState.AddModelError("Product.SmallImagePath", "File size cannot be more then 2Mb");
                    }
                    else
                    {
                    
                        string fileName = Path.GetFileNameWithoutExtension(product.SmallImageFile.FileName);
                        string extension = Path.GetExtension(product.SmallImageFile.FileName).ToLower();
                        if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                        {
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            product.SmallImagePath = "~/SmallImages/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/SmallImages/"), fileName);
                            product.SmallImageFile.SaveAs(fileName);
                        }
                        else
                        {
                            ModelState.AddModelError("Product.SmallImagePath", "Only Upload .jpg , .jpeg or .png Files");
                        }
                    }
                }

                //Check for Large Image Validation if present
                if (product.LargeImageFile != null && product.LargeImageFile.ContentLength > 0)
                {
                    if (product.LargeImageFile.ContentLength > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Product.LargeImagePath", "File size cannot be more then 5Mb");
                    }
                    else
                    {
                    
                        string fileName = Path.GetFileNameWithoutExtension(product.LargeImageFile.FileName);
                        string extension = Path.GetExtension(product.LargeImageFile.FileName).ToLower();
                        if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                        {
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            product.LargeImagePath = "~/LargeImages/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/LargeImages/"), fileName);
                            product.LargeImageFile.SaveAs(fileName);
                        }
                        else
                        {
                            ModelState.AddModelError("Product.LargeImagePath", "Only Upload .jpg , .jpeg or .png Files");
                        }
                    }
                }

                //Add product to database if No Error found
                if (ModelState.IsValid)
                {
                    
                    Product newProduct = new Product
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ShortDescription = product.ShortDescription,
                        LongDescription = product.LongDescription,
                        SmallImagePath = product.SmallImagePath,
                        LargeImagePath = product.LargeImagePath,
                        CategoryId = product.CategoryId
                    };

                    //Callig WebApi ProductsController ( POST: api/Products ) Method
                    HttpResponseMessage responseMessage = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", newProduct).Result;

                    TempData["Type"] = "0";
                    TempData["Message"] = "Product Created Successfully   Probuct :" + product.Name;

                    //Adding Log to File and Database
                    string UserId = User.Identity.GetUserId();
                    Log.Info("Product Created with Name(" + product.Name + ") by User [ " + UserId + " ]");

                    return RedirectToAction("Index", "Product");
                }

                //If Any Error occures then return to view
                var viewModel = new ProductViewModel
                {
                    Product = product,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }
            catch
            {
                //Throw to User Defined Error File ( UserExceptionHandler )
                throw;
            }
        }

        [Authorize]
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            //Callig WebApi ProductsController ( GET: api/Products/5 ) Method
            HttpResponseMessage responseMessage = GlobalVariables.WebApiClient.GetAsync("Products/"+id.ToString()).Result;
            Product product = responseMessage.Content.ReadAsAsync<Product>().Result;

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductViewModel
            {
                Product = product,
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                //Check for Small Image Validation if present
                if (product.SmallImageFile != null && product.SmallImageFile.ContentLength > 0)
                {
                    if (product.SmallImageFile.ContentLength > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Product.SmallImagePath", "File size cannot be more then 2Mb");
                    }
                    else
                    {
                        //If Image already exists then remove it from File Path
                        if (System.IO.File.Exists(Server.MapPath(product.SmallImagePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(product.SmallImagePath));

                        }
                        string fileName = Path.GetFileNameWithoutExtension(product.SmallImageFile.FileName);
                        string extension = Path.GetExtension(product.SmallImageFile.FileName).ToLower();
                        if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                        {
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            product.SmallImagePath = "~/SmallImages/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/SmallImages/"), fileName);
                            product.SmallImageFile.SaveAs(fileName);
                        }
                        else
                        {
                            ModelState.AddModelError("Product.SmallImagePath", "Only Upload .jpg , .jpeg or .png Files");
                        }
                    }
                }

                //Check for Large Image Validation if present
                if (product.LargeImageFile != null && product.LargeImageFile.ContentLength > 0)
                {
                    if (product.LargeImageFile.ContentLength > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Product.LargeImagePath", "File size cannot be more then 5Mb");
                    }
                    else
                    {
                        //If Image already exists then remove it from File Path
                        if (System.IO.File.Exists(Server.MapPath(product.LargeImagePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(product.LargeImagePath));

                        }
                        string fileName = Path.GetFileNameWithoutExtension(product.LargeImageFile.FileName);
                        string extension = Path.GetExtension(product.LargeImageFile.FileName).ToLower();
                        if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                        {
                            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            product.LargeImagePath = "~/LargeImages/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/LargeImages/"), fileName);
                            product.LargeImageFile.SaveAs(fileName);
                        }
                        else
                        {
                            ModelState.AddModelError("Product.LargeImagePath", "Only Upload .jpg , .jpeg or .png Files");
                        }
                    }
                }
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Product editProduct = new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ShortDescription = product.ShortDescription,
                        LongDescription = product.LongDescription,
                        SmallImagePath = product.SmallImagePath,
                        LargeImagePath = product.LargeImagePath,
                        CategoryId = product.CategoryId
                    };

                    //Callig WebApi ProductsController ( PUT: api/Products/5 ) Method
                    HttpResponseMessage responseMessage = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + product.Id, editProduct).Result;

                    TempData["Type"] = "1";
                    TempData["Message"] = "Product Edited Successfully   Probuct :" + product.Name;

                    //Adding Log to File and Database
                    string UserId = User.Identity.GetUserId();
                    Log.Info("Product Edited with Id(" + product.Id + ") by User [ " + UserId + " ]");

                    return RedirectToAction("Index", "Product");
                }
                var viewModel = new ProductViewModel
                {
                    Product = product,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);

            }
            catch
            {
                //Throw to User Defined Error File ( UserExceptionHandler )
                throw;
            }
        }

        [Authorize]
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                //Callig WebApi ProductsController ( GET: api/Products/5 ) Method
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
                Product product = response.Content.ReadAsAsync<Product>().Result;

                if (product == null)
                {
                    return HttpNotFound();
                }

                //If Image exists then remove it from File Path
                if (System.IO.File.Exists(Server.MapPath(product.SmallImagePath)))
                {
                    System.IO.File.Delete(Server.MapPath(product.SmallImagePath));

                }

                //If Image exists then remove it from File Path
                if (System.IO.File.Exists(Server.MapPath(product.LargeImagePath)))
                {
                    System.IO.File.Delete(Server.MapPath(product.LargeImagePath));

                }

                //Callig WebApi ProductsController ( DELETE: api/Products/5 ) Method
                HttpResponseMessage responseMessage = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;


                TempData["Type"] = "2";
                TempData["Message"] = "Product Removed Successfully   Probuct :" + product.Name;

                //Adding Log to File and Database
                string UserId = User.Identity.GetUserId();
                Log.Info("Product Deleted with Id(" + product.Id + ") by User [ " + UserId + " ]");

                return RedirectToAction("Index");
            }
            catch
            {
                //Throw to User Defined Error File ( UserExceptionHandler )
                throw;
            }
            
        }

        [Authorize]
        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult MultiDelete(IEnumerable<int> Ids)
        {
            try
            {
                string name = "";
                string UserId = User.Identity.GetUserId();
                
                //Delete Every Product using Ids
                foreach (var Id in Ids)
                {
                    //Callig WebApi ProductsController ( GET: api/Products/5 ) Method
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + Id.ToString()).Result;
                    Product product = response.Content.ReadAsAsync<Product>().Result;
                    if (product != null)
                    {
                        name = name + product.Name + " ,";

                        //If Image exists then remove it from File Path
                        if (System.IO.File.Exists(Server.MapPath(product.SmallImagePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(product.SmallImagePath));
                        }

                        //If Image exists then remove it from File Path
                        if (System.IO.File.Exists(Server.MapPath(product.LargeImagePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(product.LargeImagePath));
                        }

                        //Callig WebApi ProductsController ( DELETE: api/Products/5 ) Method
                        HttpResponseMessage responseMessage = GlobalVariables.WebApiClient.DeleteAsync("Products/" + Id.ToString()).Result;

                        //Adding Log to File and Database
                        Log.Info("Product Deleted with Id(" + product.Id + ") by User [ " + UserId + " ]");

                    }
                }

                TempData["Type"] = "2";
                if (name.Equals(""))
                    TempData["Type"] = "3";

                TempData["Message"] = "Product Removed Successfully   Probuct ::" + name;
                return RedirectToAction("Index");
            }
            catch
            {
                //Throw to User Defined Error File ( UserExceptionHandler )
                throw;
            }
        }
    }
}
