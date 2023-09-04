﻿using Microsoft.AspNetCore.Mvc;
using ConvertJS.DTOs;
using RestSharp;
using ConvertJS.Services;
using ConvertJS.Services.AccountServices;

namespace ConvertJS.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("AdAccount")]
        public async Task<object> AdAccount(string accessTokenInfo, string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                AccountService accountService = new AccountService();
                return await accountService.AdAccount(accessTokenInfo, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("Account")]
        public async Task<object> Account(string accessTokenInfo, string cookie)
        {
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                AccountService accountService = new AccountService();
                return await accountService.Account(accessTokenInfo, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("businesses")]
        public async Task<object> Businesses(string accessTokenInfo, string cookie)
        {
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                AccountService accountService = new AccountService();
                return await accountService.Businesses(accessTokenInfo, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("business_users")]
        public async Task<object> Businesses_user(string accessTokenInfo,string idbm, string cookie)
        {
            //idbm = "175611061867784";// truyen them id 
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                AccountService accountService = new AccountService();
                return await accountService.Businesses_user(accessTokenInfo, idbm, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("delete_user_ad")]
        public async Task<object> Delete_user_ad(string accessTokenInfo, string id_tkqc, string id_user, string cookie)
        {
            //id_user = "100000980779782";
            //id_tkqc = "1334960267106066";
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                AccountService accountService = new AccountService();
                return await accountService.Delete_user_ad(accessTokenInfo,id_tkqc,id_user, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
    }
}
