using ConvertJS.Infras.Constants;
using ConvertJS.Services.RulesServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Account.SetRules
{
    public class AdSetManagerController : Controller
    {
        private readonly ILogger<AdSetManagerController> _logger;
        private readonly IRulesService _rulesService;
        public AdSetManagerController(ILogger<AdSetManagerController> logger, IRulesService rulesService)
        {
            _logger = logger;
            _rulesService = rulesService;
        }

        public async Task<IActionResult> Index()
        {
            var adSets = await _rulesService.get_all_adset_from_camp("", "", "");
            ViewData[KeyTranfer.GET_AD_SET] = adSets;
            return View();
        }
    }
}
