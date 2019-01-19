using MatesCarSite;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MatesCarSite.Models;

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
        protected ApplicationDbContext mContexct;

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
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            mContexct = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
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

        /// <summary>
        /// Creates out single user for now
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser
            {
                UserName = "Witold",
                Email = "contat@me.com"
            }, "password");
            if(result.Succeeded)
                return Content("User was created", "text/html");


            return Content("User creation failed", "text/html");
        }


        /// <summary>
        /// Private area no peeking.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        [Route("logout")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content("done", "text/html");

        }

        /// <summary>
        /// An auto-login page for testing
        /// </summary>
        /// <param name="returnUrl">The url to return to if successfully logged in</param>
        /// <returns></returns>
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            //Sign out any previous sessions
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            
            // Sign user with the valid credentials
            var result = await mSignInManager.PasswordSignInAsync("Witold", "password", true, false);
            //If succesfull...
            if (result.Succeeded)
            {
                //if we have no return URL
                if (string.IsNullOrEmpty(returnUrl))
                    //Go to home
                    return RedirectToAction(nameof(Index));
                //otherwise, go to the return url
                return Redirect(returnUrl);
            }


            return Content("Failed to login", "text/html");
        }

        [Route("test")]
        public SettingsDataModel Test(SettingsDataModel model)
        {
            return new SettingsDataModel { Id = "some id", Name = "Luke", Value = "10" };
        }
        public ViewResult NotIndex()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is validation error
                return View();
            }

        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
