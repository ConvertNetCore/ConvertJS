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
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"]; 
            var response = await _accountService.Businesses(accessToken, cookie);
            ViewData[KeyTranfer.BM_ACCOUNT_KEY] = response;
            return View();
        }

        public async Task<IActionResult> DeleteUser(string userId, string idTKQC)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            bool isSuccess = await _accountService.Delete_user_ad(accessToken, idTKQC, userId, cookie);
            if (isSuccess) TempData[KeyTranfer.DELETE_USER_ADACCOUNT] = MessageResponse.DeleteUserSuccess;
            else TempData[KeyTranfer.DELETE_USER_ADACCOUNT] = MessageResponse.DeleteUserUnsuccess;
            return RedirectToAction("");
        }
    }
}
