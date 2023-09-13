using ConvertJS.Infras.Constants;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.RulesServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

namespace ConvertJS.Controllers.Display.Account.SetRules
{
    public class SetRuleAllAccountController : Controller
    {

        private readonly IRulesService _ruleService;
        public SetRuleAllAccountController(IRulesService ruleService)
        {
            _ruleService = ruleService;
        }
        public async Task<IActionResult> Index()
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            var ruleAllAccount = await _ruleService.GetAllAccount(accessToken, cookie);
            ViewData[KeyTranfer.RULE_GET_ALL_ACCOUNT] = ruleAllAccount;
            return View();
        }
    }
}
