using MatesCarSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Controllers
{

    /// <summary>
    /// Manages the standard web server pages
    /// </summary>
    public class HomeController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected ApplicationDbContext context;

        /// <summary>
        /// The manager for  handling user creation, deletion, searching, roles etc...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// The manager for handling signing in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The injected context</param>
        public HomeController(ApplicationDbContext _context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            context = _context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }
        #endregion
        #region Actions

        [Authorize]
        public ViewResult Index() => View(GetData(nameof(Index)));

        [Authorize(Roles = "Admin,Admins")]
        public IActionResult OtherAction() => View("Index", GetData(nameof(OtherAction)));

        
        
        /// <summary>
        /// Redirects to this page in case some error occurs
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Debts()
        {
            var debtsOfUser = context.Debts.Where(debt => debt.NameOfLoanHolder.ToUpper() == HttpContext.User.Identity.Name.ToUpper());
            
            return View(debtsOfUser);
        }

        


        #endregion
        #region Helper functions

        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Autheticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users")
            };

        #endregion
    }
}
