using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.RegisterExtension
{
    public class RegisterController : Controller
    {
        public IActionResult Index([FromQuery] string cookie, string accessToken, string fb_dtsg, string jazoest)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("cookie", cookie, options);
            Response.Cookies.Append("accessToken", accessToken, options);
            Response.Cookies.Append("fb_dtsg", fb_dtsg, options);
            Response.Cookies.Append("jazoest", jazoest, options);
            return Redirect("/Home");
        }
    }
}
