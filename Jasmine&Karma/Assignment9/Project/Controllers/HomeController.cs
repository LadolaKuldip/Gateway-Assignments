using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Repository;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetDataRepository _data;

        public HomeController(IGetDataRepository data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string[] GetAll()
        {
            return _data.GetAll();
        }
        
        public string GetNameById(int id)
        {
            return _data.GetNameById(id);
        }
    }
}
