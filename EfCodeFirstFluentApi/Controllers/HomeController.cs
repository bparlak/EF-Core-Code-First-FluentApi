using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCodeFirstFluentApi.Models;
using EfCodeFirstFluentApi.Models.Manager;

namespace EfCodeFirstFluentApi.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext database;
        public HomeController(DatabaseContext _database)
        {
            database = _database;
        }
        public IActionResult Index()
        {
            
            return View(database.Customers.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
