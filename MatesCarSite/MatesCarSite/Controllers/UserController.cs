using MatesCarSite.Models;
using MatesCarSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if(model.Password == model.PasswordConfirm)
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
                ModelState.AddModelError("", Resources.Errors.PasswordNotTheSame);
                model.PasswordConfirm = "";
                model.Password = "";

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
            var user = await userManager.GetUserAsync(HttpContext.User);
            var result = context.Friends?.Where(f => f.UserRef == user);
            List<ApplicationUser> userFriendsList = new List<ApplicationUser>();
            if (result!=null)
            {
                var nonFilteredUsers = context.Users.ToList();
                
                foreach (var friend in result)
                {
                    var friendsToDisplay = nonFilteredUsers.First(a => a == friend.UserFriendRef);
                    if (friendsToDisplay != null)
                        userFriendsList.Add(friendsToDisplay);
                }
                
            }
            return View(userFriendsList);
        }

        public async Task<IActionResult> AddFriend()
        {
            List<ApplicationUser> getUsers;
            var user = await userManager.GetUserAsync(HttpContext.User);
            getUsers = userManager.Users.ToList() ?? new List<ApplicationUser>();
            if(getUsers.Count > 0)
            {
                getUsers.Remove(user);
                var alreadyFriends = context.Friends.Where(e => e.UserRef == user);
                if(alreadyFriends != null)
                {
                    List<ApplicationUser> alreadyFriendsList = new List<ApplicationUser>();
                    foreach (var aFriend in alreadyFriends)
                    {
                        alreadyFriendsList.Add(aFriend.UserFriendRef);
                    }
                    if(alreadyFriendsList != null)
                    {
                        foreach (var friend in alreadyFriendsList)
                        {
                            getUsers.Remove(friend);
                        }
                        return View(getUsers);
                    }
                        
                }
            }
            return Content("BŁĄDSDSADSASD");
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(string friendName)
        {
            if (friendName != null)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                var friendToAdd = await userManager.FindByNameAsync(friendName);
                if (friendToAdd != null)
                {
                    if (friendToAdd != null && user != null)
                    {
                        context.Friends.Add(new Friend
                        {
                            UserRef = user,
                            UserFriendRef = friendToAdd
                        });
                        var result = await context.SaveChangesAsync();
                        if (result != 0)
                            return RedirectToAction("Friends");
                    }
                }
            }
            
            return Content("COŚ POSZŁO W CHUJ NIE TAK ZNOWU");
            
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFriend(string friendName)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var friendToAdd = await userManager.FindByNameAsync(friendName);
            if (friendToAdd != null)
            {
                if (friendToAdd != null && user != null)
                {
                    var friendship = context.Friends.ToList();
                    var friendsToDelete = friendship.FindAll(e => e.UserRef == user && e.UserFriendRef == friendToAdd);
                    context.Friends.RemoveRange(friendsToDelete);
                    var result = await context.SaveChangesAsync();
                    if (result != 0)
                        return RedirectToAction("Friends");

                }
            }
            return Content("COŚ POSZŁO W CHUJ NIE TAK ZNOWU");

        }

        #endregion
    }
}