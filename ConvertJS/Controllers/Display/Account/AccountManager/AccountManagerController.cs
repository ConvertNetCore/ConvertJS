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
            var accessTokenInfo = "EAABsbCS1iHgBO8xVJgHkWhIpnQuNkqs0c199uogxWiHh78dzA5Fwu53svJ6NwYMlHLHKP1NJeogj9qutmZBC1DzNFwj9NzXbzhZCNSAS8Dos63DBxJccGn06RSVDQZCt2I3d1ZCtXY4zqpMZBFcK5lYCLi7yp9lrPWzVyfif8fBewujd1j6SUlIBaG2rUNoZCeCo38CZCx6ugZDZD";
            var cookie = "sb=bmzhZM6Yj9xhYcY88PAm--ha; datr=bmzhZEXytI4OLbFTxarIbfaU; wl_cbv=v2%3Bclient_version%3A2317%3Btimestamp%3A1693823286; m_pixel_ratio=1.25; wd=1536x754; locale=en_GB; dpr=1.25; c_user=100003750097058; m_page_voice=100003750097058; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1693835621717%2C%22v%22%3A1%7D; xs=42%3Asxo7zud7h0wcug%3A2%3A1693834741%3A-1%3A8096%3A%3AAcX0M9pbunCX6VQVEFcjm7he4GntgvBxnZX_Fequgw; fr=0dC9lHZrEzRKEnYVz.AWW9fEXe454-xqyOLU-Z-VGh83U.Bk9ekd.Ew.AAA.0.0.Bk9fa8.AWVKJgrPWo4";
            var response = await _accountService.AdAccount(accessTokenInfo, cookie);
            ViewData[KeyTranfer.AD_ACCOUNT_KEY] = JsonConvert.SerializeObject(response);
            return View();
        }
    }
}
