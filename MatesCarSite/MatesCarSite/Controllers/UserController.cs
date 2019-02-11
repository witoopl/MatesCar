using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatesCarSite.Models;
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
        public async Task<IActionResult> Register(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View("Error");
            else
            {
                return View();
            }
        }

        #endregion
    }
}