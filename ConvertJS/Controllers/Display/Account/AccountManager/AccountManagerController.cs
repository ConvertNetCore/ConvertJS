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
            var accessTokenInfo = "EAABsbCS1iHgBOx2niLQdZBbGiiGQ0j0UygN8Q8BTE2XIZARvJTuKDosZCgeZBKWbNhMO8AZCWOGUfp09KaFLZBBkgpSk2rp0NhlWjAzYzrXl5fZC13ZC08ZAxYMC3VZA73P2gtxuoh8S3glZCEie0kidBFEhRbxQELrTHgxRkQGtVZAYadVeO9J3fAOSaSgZBwgZDZD";
            var cookie = "sb=bmzhZM6Yj9xhYcY88PAm--ha; datr=bmzhZEXytI4OLbFTxarIbfaU; wl_cbv=v2%3Bclient_version%3A2322%3Btimestamp%3A1694189609; locale=en_GB; usida=eyJ2ZXIiOjEsImlkIjoiQXMwdnY1b29lbDF2aSIsInRpbWUiOjE2OTQ1Mzk2NDR9; wd=1536x754; dpr=1.25; c_user=100032564511545; xs=15%3AN7sZQoQR-JOdYg%3A2%3A1694540230%3A-1%3A6385; fr=03egxM9KoouB4WLIR.AWVi7AVXkErpWoE396HcdNIHb6g.BlAKFo.Ew.AAA.0.0.BlAKHQ.AWVvMwABGeQ; presence=EDvF3EtimeF1694540318EuserFA21B32564511545A2EstateFDutF0CEchF_7bCC; m_page_voice=100032564511545";
            List<AdsAccountDTO> getAllUserDTO = await _accountService.AdAccount(accessTokenInfo, cookie);
            ViewData[KeyTranfer.AD_ACCOUNT_KEY] = getAllUserDTO;
            return View();
        }
    }
}
