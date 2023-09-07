using ConvertJS.DTOs;
using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Constants;
using ConvertJS.Infras.Enums;
using ConvertJS.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ConvertJS.Controllers.Display.Account.AccountManager
{
    public class AccountManagerController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountManagerController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var accessTokenInfo = "EAABsbCS1iHgBOzixqNtN7udy0QZCu9J22wBFQHRbmWZAzUHr5yvUaLjtimJcxQlbUpSq5cKrSdFgRbt0W5JK11XZB0BAJGhBcNq1LNWqGgObdYkDceyQvvYgyVmxACvZBqBlOFBZBns5mA35GpLdAJWFCqVeIBlFUk2E64cqyGBywYZAkmGIu6GdDZCMJzf7VhaH0Y6AfohygZDZD";
            var cookie = "sb=bmzhZM6Yj9xhYcY88PAm--ha; datr=bmzhZEXytI4OLbFTxarIbfaU; wl_cbv=v2%3Bclient_version%3A2317%3Btimestamp%3A1693823286; locale=en_GB; c_user=100003750097058; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1694011239379%2C%22v%22%3A1%7D; wd=1600x791; dpr=1; m_page_voice=100003750097058; xs=1%3AhaKzF7KZ6kYtcg%3A2%3A1694011229%3A-1%3A8096%3A%3AAcWHLBzFPBxgp9V3EBr4wymFCmVYvrwuc-wZ7M7u3A; fr=0u2zJXyB7hirfs7qe.AWVrVFVS9lW97ns4kJU9ujyKZwc.Bk-I-U.Ew.AAA.0.0.Bk-I-U.AWXq4kMYWsI";
            List<AdsAccountDTO> getAllUserDTO = await _accountService.AdAccount(accessTokenInfo, cookie);
            ViewData[KeyTranfer.AD_ACCOUNT_KEY] = getAllUserDTO;
            return View();
        }
    }
}
