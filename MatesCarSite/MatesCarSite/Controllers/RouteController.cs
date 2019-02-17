using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatesCarSite.Models;
using MatesCarSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatesCarSite.Controllers
{
    [Authorize]
    public class RouteController : Controller
    {

        #region Private members

        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;

        #endregion

        #region Constructor
        public RouteController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var userList = userManager.Users.ToList();
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.FriendsList = user.Friends;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RouteCreateViewModel route)
        {
            var userList = userManager.Users.ToList();
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.FriendsList = user.Friends;
            Route tempRoute = new Route
            {
                ChargeForPassenger = route.ChargeForPassenger,
                Driver = route.Driver,
                EndLocation = route.EndLocation,
                StartLocation = route.StartLocation,
                FuelUsage = route.FuelUsage,
                IsFullyPaid = route.IsFullyPaid,
                Passengers = new List<ApplicationUser>()

            };
            if (ModelState.IsValid)
            {
                context.Routes.Add(route);
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else return View(route);

            }
            else
                return View(route);
        }

        public IActionResult Routes()
        {
            var routesOfUser = context.Routes?.Where(route => route.Driver.UserName.ToUpper() == HttpContext.User.Identity.Name.ToUpper());


            return View(routesOfUser);
        }

        /// <summary>
        /// Debug method to get all eviromental variables. To delete 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Zasady()
        {

            var klucze = new string[Infrastructure.GetAllEvsClass.zasadyAplikacji.Count];
            Infrastructure.GetAllEvsClass.zasadyAplikacji.Keys.CopyTo(klucze, 0);
            var wartosci = new string[Infrastructure.GetAllEvsClass.zasadyAplikacji.Count];
            Infrastructure.GetAllEvsClass.zasadyAplikacji.Values.CopyTo(wartosci,0);
            var dane = new Dictionary<string, string>();
            for (int i = 0; i < Infrastructure.GetAllEvsClass.zasadyAplikacji.Count; i++)
                dane.Add(klucze[i], wartosci[i]);
            return View(dane);
        }
        #endregion

        #region HelperFunctions
        /// <summary>
        /// Function to get all passengers from RouteCreateViewModel and insert it into RouteModel
        /// </summary>
        /// <returns></returns>
        private List<ApplicationUser> GetPassengers()
        {
            return new List<ApplicationUser>();
        }

        #endregion
    }
}