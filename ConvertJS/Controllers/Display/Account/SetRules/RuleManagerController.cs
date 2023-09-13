﻿using ConvertJS.Infras.Constants;
using ConvertJS.Services.RulesServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Account.SetRules
{
    public class RuleManagerController : Controller
    {
        private readonly ILogger<RuleManagerController> _logger;
        private readonly IRulesService _rulesService;
        public RuleManagerController(ILogger<RuleManagerController> logger, IRulesService rulesService)
        {
            _logger = logger;
            _rulesService = rulesService;
        }
        public async Task<IActionResult> Index()
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            string idTkqc = Request.Cookies["idTkqc"];
            var rules = await _rulesService.GetRule(accessToken, cookie, idTkqc);
            ViewData[KeyTranfer.GET_ALL_RULE] = rules;
            return View();
        }
    }
}
