using ConvertJS.Infras.Constants;
using ConvertJS.Services.RulesServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Account.SetRules
{
    public class CampaignsManagerController : Controller
    {
        private readonly ILogger<CampaignsManagerController> _logger;
        private readonly IRulesService _rulesService;
        public CampaignsManagerController(ILogger<CampaignsManagerController> logger, IRulesService rulesService)
        {
            _logger = logger;
            _rulesService = rulesService;
        }

        public async Task<IActionResult> Index([FromQuery] string idTkqc)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            if (idTkqc != null) Response.Cookies.Append("idTkqc", idTkqc);
            var campaigns = await _rulesService.get_all_camp_from_id_tkqc(accessToken, idTkqc,cookie);
            ViewData[KeyTranfer.GET_ALL_CAMPAIGN] = campaigns;
            return View();
        }
    }
}
