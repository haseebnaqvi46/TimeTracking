using Microsoft.AspNetCore.Mvc;

namespace TimeTracking.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
