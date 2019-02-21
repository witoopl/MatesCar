using MatesCarSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Controllers
{
    [Authorize]
    public class DebtController : Controller
    {
        #region Private members

        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;

        #endregion

        #region Constructor
        public DebtController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            var userDebts = context.Debts.Where(d => d.IdLoanDebtor == user.Id);

            return View(userDebts.ToList());

        }

        #endregion
    }
}