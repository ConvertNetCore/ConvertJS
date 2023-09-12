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
        public async Task<IActionResult> Index(string cookie, string token)
        {
            var Pages = await _appealCheckService.GetPage(cookie, token);
            ViewData[KeyTranfer.APPEAL_CHECK_PAGE] = Pages;
            return View();
        }
    }
}
