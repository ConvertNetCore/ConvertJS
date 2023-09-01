using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
