using Microsoft.AspNetCore.Mvc;
using ConvertJS.DTOs;
using RestSharp;
using ConvertJS.Services;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AdSpyServices;
using ConvertJS.DTOs.ResponseDTO;

namespace ConvertJS.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("AdAccount")]
        public async Task<List<AdsAccountDTO>> AdAccount(string accessTokenInfo, string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                return await _accountService.AdAccount(accessTokenInfo, cookie);
            }
            else
            {
                return null;
            }
        }
        [HttpGet("Account")]
        public async Task<object> Account(string accessTokenInfo, string cookie)
        {
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                return await _accountService.Account(accessTokenInfo, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("businesses")]
        public async Task<List<BusinessDTO>> Businesses(string accessTokenInfo, string cookie)
        {
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            
                return await _accountService.Businesses(accessTokenInfo, cookie);
            
        }
        [HttpGet("business_users")]
        public async Task<object> Businesses_user(string accessTokenInfo,string idbm, string cookie)
        {
            //idbm = "175611061867784";// truyen them id 
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                return await _accountService.Businesses_user(accessTokenInfo, idbm, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("delete_user_ad")]
        public async Task<DeleteDTO> Delete_user_ad(string accessTokenInfo, string id_tkqc, string id_user, string cookie)
        {
            //id_user = "100000980779782";
            //id_tkqc = "1334960267106066";
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            
                return await _accountService.Delete_user_ad(accessTokenInfo,id_tkqc,id_user, cookie);
            
        }
        [HttpPost("Delete_admin_bm")]
        public async Task<DeleteDTO> Delete_admin_bm(string id_bm, string id_tkqc, string id, string cookie, string fb_dtsg, string jazoest)
        {
            
                return await _accountService.Delete_admin_bm( id_bm, id_tkqc, id, cookie, fb_dtsg, jazoest);
            
        }
        [HttpPost("Delete_account_bm")]
        public async Task<DeleteDTO> Delete_account_bm(string accessTokenInfo, string id_bm, string cookie)
        {
            
                return await _accountService.Delete_account_bm( accessTokenInfo,  id_bm,  cookie);
           
        }
        [HttpGet("Invite_user")]
        public async Task<DeleteDTO> Invite_user(string accessTokenInfo, string id_tkqc, string id_user, string cookie)
        {
           
                return await _accountService.Invite_user(accessTokenInfo, id_tkqc, id_user, cookie);
           
        }
    }
}
