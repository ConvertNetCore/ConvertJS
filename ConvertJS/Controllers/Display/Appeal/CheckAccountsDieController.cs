using ConvertJS.Infras.Constants;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.Appeal
{
    public class CheckAccountsDieController : Controller
    {
        private readonly ILogger<CheckAccountsDieController> _logger;
        private readonly IAppealCheckService _appealCheckService;
        public CheckAccountsDieController(ILogger<CheckAccountsDieController> logger, IAppealCheckService appealCheckService)
        {
            _logger = logger;
            _appealCheckService = appealCheckService;
        }

        public async Task<IActionResult> Index(string token)
        {
            var accessTokenInfo = "EAABsbCS1iHgBO2vOVvaKekv8fAREUlXjZBZAlHZBQZAl69dmYFfj56Bwhmn1URfaDI1COEpo2ueZBQRLpYvcTU3BRjaSDcAhwndh4Hsuj9inrZAsAZCy8leGyeIEJAsD4W8ZBKK8ZCeKuZBprJxxq0c7ZCFaIjiZCYnYZC4opiZAD5TF33RrxCNSkfXUUrugI1TQZDZD";
            var cookie = "sb=bmzhZM6Yj9xhYcY88PAm--ha; datr=bmzhZEXytI4OLbFTxarIbfaU; wl_cbv=v2%3Bclient_version%3A2322%3Btimestamp%3A1694189609; locale=en_GB; usida=eyJ2ZXIiOjEsImlkIjoiQXMwdmtucTF0aDI4MGYiLCJ0aW1lIjoxNjk0NTI2MDM4fQ%3D%3D; wd=1536x754; dpr=1.25; c_user=100032564511545; xs=15%3AU77dY3YMpLfZKw%3A2%3A1694534070%3A-1%3A6385; fr=0KamHzEDMBBdz3nQD.AWXZr_J9uWJCMYJWSLWAJX4e_ok.BlAIWv.Ew.AAA.0.0.BlAI-f.AWXinEgwqXs; presence=C%7B%22lm3%22%3A%22u.100023987804498%22%2C%22t3%22%3A%5B%7B%22o%22%3A0%2C%22i%22%3A%22u.100028548182729%22%7D%5D%2C%22utc3%22%3A1694535775353%2C%22v%22%3A1%7D; m_page_voice=100032564511545";
            var accounts = await _appealCheckService.GetAccountDie(cookie, accessTokenInfo);
            ViewData[KeyTranfer.APPEAL_CHECK_ACCOUNT] = accounts;
            return View();
        }
    }
}
