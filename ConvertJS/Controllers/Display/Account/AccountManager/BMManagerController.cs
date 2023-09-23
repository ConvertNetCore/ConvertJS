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
        public async Task<IActionResult> Index(DeleteDTO model)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"]; 
            var response = await _accountService.Businesses(accessToken, cookie);
            ViewData[KeyTranfer.BM_ACCOUNT_KEY] = response;
            ViewData[KeyTranfer.DELETE_BM] = model;
            return View();
        }

        public async Task<IActionResult> DeleteAdmin(string userId, string idTKQC)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            userId = userId.Replace("act_", "");
            idTKQC = idTKQC.Replace("act_", "");
            var response = await _accountService.Delete_user_ad(accessToken, idTKQC, userId, cookie);
            return RedirectToAction("",response);
        }
        public async Task<IActionResult> DeleteAccount(string idTKQC)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            var response = await _accountService.Delete_account_bm(accessToken, idTKQC,cookie);
            return RedirectToAction("",response);
        }
        public async Task<IActionResult> InviteUserBm(string idTkqc, string gmail, string role)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            var response = await _accountService.Invite_user_bm(accessToken, idTkqc, gmail, role, cookie);
            return RedirectToAction("Index", response);
        }
    }
}
