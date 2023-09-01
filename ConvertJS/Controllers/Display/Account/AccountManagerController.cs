using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Account
{
    [Route("account-manager")]
    public class AccountManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
