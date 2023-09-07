using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Constants;
using ConvertJS.Infras.Enums;
using ConvertJS.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConvertJS.Controllers.Display.Account.AccountManager
{
    public class BMManagerController : Controller
    {
        private readonly IAccountService _accountService;
        public BMManagerController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        private List<BMRole> GetRoles(string[] data)
        {
            var roles = new List<BMRole>();
            foreach (var item in data)
            {
                if (item == "DEVELOPER") roles.Add(BMRole.DEVELOPER);
                else roles.Add(BMRole.ADMIN);
            }
            return roles;
        }
        public async Task<IActionResult> Index()
        {
            var accessTokenInfo = "EAABsbCS1iHgBOZC0hocydI7aL4S0p38AlMT3qjpa4r19NKhquMJFt9qtr0zzvh31C0HHgrMpJn9sfUuISXceaftynnGhX5CvuCCcByMnG1Bqr3QGXRj5M8CdUhkOs92kbQMa2tTdcpgtCkGn7KZADCuOGG35btiuzXraVnsPjAUxtVXn1OsA9aZCjhNyzCenZCFKaZBFOrQZDZD";
            var cookie = "sb=Yj4uZH1Gjpgagw8XUVLgOLUB; locale=en_GB; wd=1536x715; usida=eyJ2ZXIiOjEsImlkIjoiQXMwZDFlaDFudDdkd3QiLCJ0aW1lIjoxNjkzNjYzMTcxfQ%3D%3D; datr=8zb1ZEXDehAZX4LgnpXxTD3v; dpr=1.25; c_user=100071096111263; m_page_voice=100071096111263; presence=C%7B%22lm3%22%3A%22g.3271122382932475%22%2C%22t3%22%3A%5B%5D%2C%22utc3%22%3A1693794061517%2C%22v%22%3A1%7D; xs=17%3AO3PZM00rLCodCw%3A2%3A1693792104%3A-1%3A8037%3A%3AAcWW5VtbLMh0TmB38cLhktrd39I1F5iQNTc2VE8Hlrc; fr=08gZlB2a2lrFXMxVF.AWVnJKHd3Z0h1wW3BBX4UxHvjqY.Bk9htb.tY.AAA.0.0.Bk9htb.AWUDhy1BJow";
            
            var response = await _accountService.Businesses(accessTokenInfo, cookie);
            ViewData[KeyTranfer.BM_ACCOUNT_KEY] = response;
            return View();
        }
    }
}
