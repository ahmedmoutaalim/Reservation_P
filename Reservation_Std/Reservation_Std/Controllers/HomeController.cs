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
using Reservation_Std.Contract;

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



        [Authorize]
        public IActionResult Index()
        {
            


            return View();
        }
  
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Policy = "Adminpolicy")]
        public async Task<IActionResult> AdminDashboard()
        {
            var Reservation = await this.Context.Reservations.Include(r=>r.ReservationType).Include(r=>r.Utilisateur).ToListAsync();
   
            return View(Reservation);
         
        }
        [Authorize(Policy = "Adminpolicy")]
        public async Task<IActionResult> Details(int id)
        {
            Reservation R = await this.Context.Reservations.Include(r => r.ReservationType).Include(r => r.Utilisateur).Where(x => x.Id == id).SingleOrDefaultAsync();
            return View(R);
        }



        [Authorize(Policy = "Adminpolicy")]
        public ActionResult RejectRequest(int id)
        {

            Reservation res = this.Context.Reservations.Include(r => r.ReservationType).Include(r => r.Utilisateur).Where(r => r.Id == id).Single<Reservation>();
            this.Context.Reservations.Remove(res);
            this.Context.SaveChanges();

            if (ModelState.IsValid)
            {
                TempData["m"] = "Sorry you cant reserve now repeat another time";
            }

          

            return RedirectToAction("AdminDashboard");


        }

        [Authorize(Policy = "Adminpolicy")]
        public ActionResult ApprouveRequest()
        {



            if (ModelState.IsValid)
            {

                TempData["msg"] = "Your reservation is accepted";

            }


            return RedirectToAction("AdminDashboard");


        }


        [Authorize(Policy = "Userpolicy")]
        public async Task<IActionResult> ListR()
        {
            var Reservation = await this.Context.Reservations.Include(r => r.ReservationType).Include(r => r.Utilisateur).ToListAsync();

            return View(Reservation);

        }

        [Authorize(Policy = "Userpolicy")]
        [HttpGet]
        public IActionResult UserDashboard()
        {

            return View();
        }
        [Authorize(Policy = "Userpolicy")]
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

