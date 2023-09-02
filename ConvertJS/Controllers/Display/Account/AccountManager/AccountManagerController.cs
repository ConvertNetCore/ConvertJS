using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Account.AccountManager
{
    public class AccountManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
