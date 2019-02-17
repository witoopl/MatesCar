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
    public class UserController : Controller
    {
        #region private members
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext context;
        #endregion

        #region Constructor
        public UserController(UserManager<ApplicationUser> _userManager, ApplicationDbContext _context)
        {
            userManager = _userManager;
            context = _context;
        }

        #endregion



        #region Actions

        public IActionResult Edit()
        {
            return View();
        }

        
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.Identity.Name;
            var result = await userManager.FindByNameAsync(user);
            return View(result);
        }
        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            
            if (HttpContext.User.Identity.IsAuthenticated)
                return View("Error");
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    UserFirstName = model.FirstName,
                    UserSurname = model.Surname,
                    IsDriver = model.IsDriver,
                    DefaultBankAccount = model.BankAccount,
                    PhoneNumber = model.PhoneNumber
                    
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                var roleResult = await userManager.AddToRoleAsync(user, "User");
                if (result.Succeeded && roleResult.Succeeded)
                {
                    return View("Success");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Success()
        {
            return View();
        }

        public async Task<IActionResult> Friends()
        {
            List<ApplicationUser> listOfUsers = userManager.Users.ToList();
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);

            return View(user.Friends);

            //return View("Error", "Shared");
        }
        [AllowAnonymous]
        public IActionResult Friends2()
        {
            var test = context.Users.ToList();

            return View("Friends2",test);
        }

        public async Task<IActionResult> FriendsAdd()
        {
            
            List<ApplicationUser> listOfUsers = userManager.Users.ToList();
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            listOfUsers.Remove(user);
            if(user.Friends != null && user.Friends.Count != 0)
                foreach (var friend in user.Friends)
                {
                    listOfUsers.Remove(friend);
                }
            if (listOfUsers != null)
                return View(listOfUsers);
            
            return View("Error","Shared");
        }
        [HttpPost]
        public async Task<IActionResult> FriendsAdd(string user)
        {
            
            if (user != null)
            {
                List<ApplicationUser> listOfUsers = userManager.Users.ToList();
                ApplicationUser appUser = await userManager.GetUserAsync(HttpContext.User);
                ApplicationUser newFriend = await userManager.FindByNameAsync(user);
                if (newFriend == null)
                {
                    return Redirect("FriendsAdd");
                }
                if (appUser.Friends == null)
                    appUser.Friends = new List<ApplicationUser>();
                appUser.Friends.Add(newFriend);
                var result = await userManager.UpdateAsync(appUser);
                
                if (result.Succeeded)
                {
                    //return View("Friends2", appUser.Friends);
                    return Redirect("Friends");
                }
            }


            return Redirect("Friends");
        }

        public async Task<IActionResult> FriendDelete(string friendId)
        {
            List<ApplicationUser> listOfUsers = userManager.Users.ToList();
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            var friendToDelete = await userManager.FindByIdAsync(friendId);
            if(friendToDelete!=null)
                user.Friends.Remove(friendToDelete);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Redirect("Friends");
            else
                return Content("Nie udało sie usunąć przyjaciela");
        }
        #endregion
    }
}