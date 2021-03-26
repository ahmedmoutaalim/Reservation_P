using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservation_Std.Data;
using Reservation_Std.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Reservation_Std.Controllers
{
    public class HomeController : Controller
    {
    

       
        private ApplicationDbContext Context { get; }
        private UserManager<Utilisateur> _userManager;


        public HomeController(ApplicationDbContext  _context , UserManager<Utilisateur> userManager)
        {

            _userManager = userManager;

            this.Context = _context;

        }

         


        public IActionResult Index()
        {

            return View();
        }
  
        public IActionResult Privacy()
        {
            return View();
        }

   
        public async Task<IActionResult> AdminDashboard()
        {
            var Reservation = await this.Context.Reservations.Include(r=>r.ReservationType).Include(r=>r.Utilisateur).ToListAsync();
   
            return View(Reservation);
         
        }

        public async Task<IActionResult> Details(int id)
        {
            Reservation R = await this.Context.Reservations.Include(r => r.ReservationType).Include(r => r.Utilisateur).Where(x => x.Id == id).SingleOrDefaultAsync();
            return View(R);
        }



        public async Task<IActionResult> ListR()
        {
            var Reservation = await this.Context.Reservations.Include(r => r.ReservationType).Include(r => r.Utilisateur).ToListAsync();

            return View(Reservation);

        }


        [HttpGet]
        public IActionResult UserDashboard()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UserDashboard(Reservation Rsv)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
            
                Rsv.Utilisateur =  _userManager.FindByIdAsync(userId).Result;
            }
    

            this.Context.Reservations.Add(Rsv);
            this.Context.SaveChanges();


            if (ModelState.IsValid)
            {
                TempData["msg"] = " your request is added ";
            }
           
            return View(Rsv);
        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

