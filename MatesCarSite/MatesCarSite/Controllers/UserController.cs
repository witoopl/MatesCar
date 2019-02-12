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

        #endregion

        #region Constructor
        public UserController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
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

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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

        #endregion
    }
}