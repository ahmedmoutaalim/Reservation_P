using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservation_Std.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation_Std.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Policy = "Userspolicy")]
        public IActionResult Index()
        {

            return View();
        }
        [Authorize(Policy = "Userspolicy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Policy = "Adminpolicy")]
        public IActionResult AdminDashboard()
        {
            return View();
        }
        [Authorize(Policy = "Userspolicy")]
        public IActionResult UserDashboard()
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
