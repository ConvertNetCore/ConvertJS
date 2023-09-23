using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Home
{
    public class HomeController : Controller
    {
        private readonly IAppealCheckService _appealCheckService;
        private readonly IAccountService _accountService;
        public HomeController(IAppealCheckService appealCheckService,IAccountService accountService)
        {
            _appealCheckService = appealCheckService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            string id = Request.Cookies["id_user"];
            if (id == null)
            {
                var listUser = await _accountService.AdAccount(accessToken, cookie);
                id = listUser.FirstOrDefault().Users.FirstOrDefault().UserId;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("id_user", id, options);
            }
            string fb_dtsg = Request.Cookies["fb_dtsg"];
            string jazoest = Request.Cookies["jazoest"];
            var Pages = await _appealCheckService.GetPage(accessToken, cookie, id, fb_dtsg, jazoest);
            var numberPage = Pages.Count();
            var Accounts = await _accountService.AdAccount(accessToken, cookie);
            var numberAccounts = Accounts.Count();
            var BMs = await _accountService.Businesses(accessToken, cookie);
            var numberBm = BMs.Count();
            ViewData["numberPage"] = numberPage;
            ViewData["numberAccount"] = numberAccounts;
            ViewData["numberBm"] = numberBm;
            return View();
        }
    }
}
