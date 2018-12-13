using Microsoft.AspNetCore.Mvc;

namespace MatesCarSite.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TellMeMore(string moreInfo = "")
        {
            return new JsonResult(new { name = "TellmeMore", content = moreInfo });
            return View();
        }


    }
}
