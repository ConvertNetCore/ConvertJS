using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromQuery] string cookie, string accessToken)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("cookie", cookie, options);
            Response.Cookies.Append("accessToken", accessToken, options);
            return View();
        }
    }
}
