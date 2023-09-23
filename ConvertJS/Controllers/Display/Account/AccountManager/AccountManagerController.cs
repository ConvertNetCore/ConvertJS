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

        public async Task< IActionResult> Index(DeleteDTO model)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            List<AdsAccountDTO> getAllUserDTO = await _accountService.AdAccount(accessToken, cookie);
            ViewData[KeyTranfer.AD_ACCOUNT_KEY] = getAllUserDTO;
            ViewData[KeyTranfer.INVITE_USER_KEY] = model;
            return View();
        }
        public async Task<IActionResult> DeleteUser(string userId, string idTKQC)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            bool isSuccess = (await _accountService.Delete_user_ad(accessToken, idTKQC, userId, cookie)).status;
            if (isSuccess) TempData[KeyTranfer.DELETE_USER_ADACCOUNT] = MessageResponse.DeleteUserSuccess;
            else TempData[KeyTranfer.DELETE_USER_ADACCOUNT] = MessageResponse.DeleteUserUnsuccess;
            return RedirectToAction("");
        }
        public async Task<IActionResult> InviteUser(string idTkqc, string idUser)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            var response = await _accountService.Invite_user(accessToken,idTkqc,idUser,cookie);
            return RedirectToAction("Index", response);
        }
    }
}
