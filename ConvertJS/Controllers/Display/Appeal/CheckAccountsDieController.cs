using ConvertJS.Infras.Constants;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Appeal
{
    public class CheckAccountsDieController : Controller
    {
        private readonly ILogger<CheckAccountsDieController> _logger;
        private readonly IAppealCheckService _appealCheckService;
        public CheckAccountsDieController(ILogger<CheckAccountsDieController> logger, IAppealCheckService appealCheckService)
        {
            _logger = logger;
            _appealCheckService = appealCheckService;
        }

        public async Task<IActionResult> Index()
        {

            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            var accounts = await _appealCheckService.GetAccountDie(accessToken, cookie);
            ViewData[KeyTranfer.APPEAL_CHECK_ACCOUNT] = accounts;
            return View();
        }
    }
}
