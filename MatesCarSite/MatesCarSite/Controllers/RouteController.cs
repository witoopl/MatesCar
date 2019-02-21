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
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            var userRoutes = context.Routes.Where(a => a.Driver == user).ToList();
            //List<ApplicationUser> passengers;
            //if(userRoutes.Count()!=0)
            //{
            //    passengers = new List<ApplicationUser>();
            //    foreach (var route in userRoutes)
            //    {
            //        var passegersId = context.UsersToRoutes.Where(r => r.RouteId == route.Id);
                        
            //    }
            //}

            return View(userRoutes);
        }
        public async Task<IActionResult> Create()
        { 
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            var allUserFriendsId = context.Friends.Where(i => i.User == user.Id);
            if(allUserFriendsId!=null)
            {
                List<ApplicationUser> allUserFriendsAccounts = new List<ApplicationUser>();
                List<ApplicationUser> allUsers = context.Users.ToList();
                foreach (var friend in allUserFriendsId)
                {
                    var userFriend = allUsers.First(i => i.Id == friend.UserFriend);
                    if (userFriend != null)
                    {
                        allUserFriendsAccounts.Add(userFriend);
                    }             
                }
                return View(new RouteCreateViewModel
                {
                    Passengers = allUserFriendsAccounts
                });

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RouteCreateViewModel routeViewModel, string [] passengersId)
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            var userRoutes = context.Routes.Where(a => a.Driver == user);
            if (ModelState.IsValid)
            {
                if(passengersId!=null)
                {
                    var passengersAccounts = context.Users.Where(u => passengersId.Contains(u.Id));
                    routeViewModel.Passengers = passengersAccounts.ToList();
                    Route newRoute = new Route
                    {
                        ChargeForPassenger = routeViewModel.ChargeForPassenger,
                        Driver = user,
                        EndLocation = routeViewModel.EndLocation,
                        FuelUsage = routeViewModel.FuelUsage,
                        IsFullyPaid = routeViewModel.IsFullyPaid,
                        StartLocation = routeViewModel.StartLocation,
                        Id = Guid.NewGuid().ToString()

                    };
                    context.Routes.Add(newRoute);
                    if (routeViewModel.Passengers.Count() != 0)
                    {
                        foreach (var passenger in routeViewModel.Passengers)
                        {
                            context.UsersToRoutes.Add(new UsersToRoute
                            {
                                PassengerId = passenger.Id,
                                RouteId = newRoute.Id
                            });
                            context.Debts.Add(new Debt
                            {
                                IdLoanHolder = user.Id,
                                IdLoanDebtor = passenger.Id,
                                RouteId = newRoute.Id,
                                Value = routeViewModel.ChargeForPassenger
                            });
                        }
                    }
                        
                    var result = await context.SaveChangesAsync();
                    if (result != 0)
                    {
                        return RedirectToAction("Index");
                    }
                } 
            }
            return View(routeViewModel);
        }

        public IActionResult Delete(string routeId)
        {
            
            var route = context.Routes.First(a => a.Id == routeId);
            var userToRoutes = context.UsersToRoutes.Where(i => i.RouteId == routeId);
            foreach (var userroutes in userToRoutes)
            {
                context.UsersToRoutes.Remove(userroutes);
            }
            

            return View("Index");
        }

        #endregion
    }
}