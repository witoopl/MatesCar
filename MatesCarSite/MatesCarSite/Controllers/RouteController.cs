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
            var allUserFriends = context.Friends.Where(i => i.UserRef == user);
            if(allUserFriends!=null)
            {
                List<ApplicationUser> allUserFriendsAccounts = new List<ApplicationUser>();
                List<ApplicationUser> allUsers = context.Users.ToList();
                foreach (var friend in allUserFriends)
                {
                    var userFriend = allUsers.First(i => i == friend.UserFriendRef);
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
                                PassengerRef = passenger,
                                RouteRef = newRoute
                            });
                            context.Debts.Add(new Debt
                            {
                                LoanHolderRef = user,
                                LoanDebtorRef = passenger,
                                RouteRef = newRoute,
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

        public async Task<IActionResult> Delete(string routeId)
        {
            if (routeId != null)
            {
                var route = context.Routes.First(a => a.Id == routeId);
                if(route != null)
                {
                    var userToRoutes = context.UsersToRoutes?.Where(i => i.RouteRef.Id == routeId);
                    if (userToRoutes != null)
                        foreach (var userroutes in userToRoutes)
                        {
                            context.UsersToRoutes.Remove(userroutes);
                        }
                    var debts = context.Debts.Where(i => i.RouteRef.Id == routeId);
                    if (debts != null)
                        foreach (var debt in debts)
                        {
                            context.Debts.Remove(debt);
                        }
                    context.Routes.Remove(route);
                    var result = await context.SaveChangesAsync();
                }
                
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Details(string routeId)
        {
            List<ApplicationUser> userList;
            if (routeId != null)
            {
                var route = context.Routes.First(a => a.Id == routeId);
                if (route != null)
                {
                    userManager.Users.ToList();
                    var passengersRef = context.UsersToRoutes.Where(u => u.RouteRef == route);
                    if(passengersRef!=null)
                    {
                        userList = new List<ApplicationUser>();
                        foreach (var routePassengers in passengersRef)
                        {
                            var passUser = context.Users.First(u=>u == routePassengers.PassengerRef);
                            if (passUser != null)
                                userList.Add(passUser);
                        }
                        var routeViewDetails = new RouteDetailsViewModel
                        {
                            ChargeForPassenger = route.ChargeForPassenger,
                            Driver = route.Driver,
                            EndLocation = route.EndLocation,
                            FuelUsage = route.FuelUsage,
                            Id = route.Id,
                            IsFullyPaid = route.IsFullyPaid,
                            PassengersInRoute = userList,
                            StartLocation = route.StartLocation
                        };
                        return View(routeViewDetails);
                    }
                    
                       
                }


            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}