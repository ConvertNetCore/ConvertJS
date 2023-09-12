﻿using ConvertJS.Infras.Constants;
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

        public async Task<IActionResult> Index()
        {
            var campaigns = await _rulesService.get_all_camp_from_id_tkqc("", "", "");
            ViewData[KeyTranfer.GET_ALL_CAMPAIGN] = campaigns;
            return View();
        }
    }
}
