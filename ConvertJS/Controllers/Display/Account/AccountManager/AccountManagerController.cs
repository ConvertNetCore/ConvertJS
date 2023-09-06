using ConvertJS.DTOs;
using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Constants;
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
            var accessTokenInfo = "EAABsbCS1iHgBOxmhCfTZAzv3YXbJUPSb8U7ElH6CqWbZCIjPZAPbGA0gIZCa1uE1IPWo0SXudibOysXCOZBEQEIZBwUuIHzhl22pF7XwwcDRkVPWUOPjkKH4YdZBVHK4oTjvMjBVKPIAc824c1MIzvZBqzh1iQ6VxMt8RlI7BEew6Yqnj9fTlIydn2E9FoAn15BZBlbI7I51ZCGgZDZD";
            var cookie = "sb=bmzhZM6Yj9xhYcY88PAm--ha; datr=bmzhZEXytI4OLbFTxarIbfaU; wl_cbv=v2%3Bclient_version%3A2317%3Btimestamp%3A1693823286; locale=en_GB; dpr=1; c_user=100003750097058; xs=46%3An1q9Zhn0tuQ5vQ%3A2%3A1693922658%3A-1%3A8096; fr=0uu8jdkqY5O48dETh.AWVwvD583-a1rhw7_kEzu1RGl6k.Bk9zJ0.Ew.AAA.0.0.Bk9zV6.AWX9nsY3g0M; wd=1600x789; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1693922690949%2C%22v%22%3A1%7D; m_page_voice=100003750097058";
            var response = await _accountService.AdAccount(accessTokenInfo, cookie);
            ViewData[KeyTranfer.AD_ACCOUNT_KEY] = JsonConvert.DeserializeObject<AdAccountResponseDTO>(response.ToString());
            return View();
        }
    }
}
