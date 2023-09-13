using ConvertJS.Infras.Constants;
using ConvertJS.Services.RulesServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Account.SetRules
{
    public class AdsManagerController : Controller
    {
        private readonly ILogger<AdsManagerController> _logger;
        private readonly IRulesService _rulesService;
        public AdsManagerController(ILogger<AdsManagerController> logger, IRulesService rulesService)
        {
            _logger = logger;
            _rulesService = rulesService;
        }
        public async Task<IActionResult> Index([FromQuery] string idAdset)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            var Ads = await _rulesService.get_all_ads_from_adset(accessToken, idAdset, cookie);
            ViewData[KeyTranfer.GET_ADS] = Ads;
            return View();
        }
    }
}
