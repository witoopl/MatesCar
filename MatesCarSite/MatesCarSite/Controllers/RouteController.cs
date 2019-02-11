using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatesCarSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatesCarSite.Controllers
{
    public class RouteController : Controller
    {

        #region Private members

        private ApplicationDbContext context;

        #endregion

        #region Constructor
        public RouteController(ApplicationDbContext _context)
        {
            context = _context;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Route route)
        {
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
            var routesOfUser = context.Routes.Where(route => route.Driver.UserName.ToUpper() == HttpContext.User.Identity.Name.ToUpper());


            return View(routesOfUser);
        }

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
    }
}