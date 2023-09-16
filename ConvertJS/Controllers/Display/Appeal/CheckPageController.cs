using ConvertJS.DTOs;
using ConvertJS.Infras.Constants;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Appeal
{
    public class CheckPageController : Controller
    {
        private readonly ILogger<CheckAccountsDieController> _logger;
        private readonly IAppealCheckService _appealCheckService;
        public CheckPageController(ILogger<CheckAccountsDieController> logger, IAppealCheckService appealCheckService)
        {
            _logger = logger;
            _appealCheckService = appealCheckService;
        }
        public async Task<IActionResult> Index()
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            string id = Request.Cookies["id"];
            string fb_dtsg = Request.Cookies["fb_dtsg"];
            string jazoest = Request.Cookies["jazoest"];
            var Pages = await _appealCheckService.GetPage(accessToken,  cookie,  id,  fb_dtsg,  jazoest);
            ViewData[KeyTranfer.APPEAL_CHECK_PAGE] = Pages;
            return View();
        }
    }
}
