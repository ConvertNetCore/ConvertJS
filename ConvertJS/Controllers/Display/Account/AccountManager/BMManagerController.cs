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
            var accessTokenInfo = "EAABsbCS1iHgBO2vOVvaKekv8fAREUlXjZBZAlHZBQZAl69dmYFfj56Bwhmn1URfaDI1COEpo2ueZBQRLpYvcTU3BRjaSDcAhwndh4Hsuj9inrZAsAZCy8leGyeIEJAsD4W8ZBKK8ZCeKuZBprJxxq0c7ZCFaIjiZCYnYZC4opiZAD5TF33RrxCNSkfXUUrugI1TQZDZD";
            var cookie = "sb=bmzhZM6Yj9xhYcY88PAm--ha; datr=bmzhZEXytI4OLbFTxarIbfaU; wl_cbv=v2%3Bclient_version%3A2322%3Btimestamp%3A1694189609; locale=en_GB; usida=eyJ2ZXIiOjEsImlkIjoiQXMwdmtucTF0aDI4MGYiLCJ0aW1lIjoxNjk0NTI2MDM4fQ%3D%3D; wd=1536x754; dpr=1.25; c_user=100032564511545; xs=15%3AU77dY3YMpLfZKw%3A2%3A1694534070%3A-1%3A6385; fr=0KamHzEDMBBdz3nQD.AWXZr_J9uWJCMYJWSLWAJX4e_ok.BlAIWv.Ew.AAA.0.0.BlAI-f.AWXinEgwqXs; presence=C%7B%22lm3%22%3A%22u.100023987804498%22%2C%22t3%22%3A%5B%7B%22o%22%3A0%2C%22i%22%3A%22u.100028548182729%22%7D%5D%2C%22utc3%22%3A1694535775353%2C%22v%22%3A1%7D; m_page_voice=100032564511545";
            var response = await _accountService.Businesses(accessTokenInfo, cookie);
            ViewData[KeyTranfer.BM_ACCOUNT_KEY] = response;
            return View();
        }
    }
}
