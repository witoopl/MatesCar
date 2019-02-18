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


        #endregion
    }
}