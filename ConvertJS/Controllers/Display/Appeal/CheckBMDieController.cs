using ConvertJS.Infras.Constants;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Appeal
{
    public class CheckBMDieController : Controller
    {
        private readonly ILogger<CheckAccountsDieController> _logger;
        private readonly IAppealCheckService _appealCheckService;
        public CheckBMDieController(ILogger<CheckAccountsDieController> logger, IAppealCheckService appealCheckService)
        {
            _logger = logger;
            _appealCheckService = appealCheckService;
        }
        public async Task<IActionResult> Index()
        {
            var BMAccounts = await _appealCheckService.GetBMDie("","");
            ViewData[KeyTranfer.APPEAL_CHECK_BM] = BMAccounts;
            return View();
        }
    }
}
