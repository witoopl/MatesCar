using MatesCarSite;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MatesCarSite.Controllers
{
    public class HomeController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected ApplicationDbContext mContexct;

        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The injected context</param>
        public HomeController(ApplicationDbContext context)
        {
            mContexct = context;
        }
        #endregion 

        public IActionResult Index()
        {  

            mContexct.Database.EnsureCreated();

            if (mContexct.Settings.Any())
            {
                mContexct.Settings.Add(new SettingsDataModel
                {
                    Name = "BackgroundColor",
                    Value = "Red"
                });
                var numberOfSettings = mContexct.Settings.Local.Count();

                var firstSettings = mContexct.Settings.First();

                mContexct.SaveChanges();
            }
            


            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
