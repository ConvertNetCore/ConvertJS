using ConvertJS.DTOs;
using ConvertJS.Infras.Constants;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AdSpyServices;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Appeal
{
    public class CheckPageController : Controller
    {
        private readonly ILogger<CheckAccountsDieController> _logger;
        private readonly IAppealCheckService _appealCheckService;
        private readonly IAccountService _accountService;
        public CheckPageController(ILogger<CheckAccountsDieController> logger, IAppealCheckService appealCheckService, IAccountService accountService)
        {
            _logger = logger;
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
            var Pages = await _appealCheckService.GetPage(accessToken,  cookie,  id,  fb_dtsg,  jazoest);
            ViewData[KeyTranfer.APPEAL_CHECK_PAGE] = Pages;
            return View();
        }
    }
}
