﻿using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AppealCheckServices;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace ConvertJS.Controllers.API
{
    
    [Route("[controller]")]
    [ApiController]
    public class AppealController : ControllerBase
    {
        private readonly IAppealCheckService _appealCheckService;
        public AppealController(IAppealCheckService appealCheckService)
        {
            _appealCheckService = appealCheckService;
        }
        [HttpPost("Khang_buoc_1")]
        public async Task<object> Khang_buoc_1(string id , string ids_issue_ent_id,string fb_dtsg,string jazoest,string uid,string cookie)
        {
            return await _appealCheckService.Khang_buoc_1(id, ids_issue_ent_id, fb_dtsg, jazoest, uid, cookie);
        }
        [HttpPost("Khang_buoc_1_pass2")]
        public async Task<object> Khang_buoc_1_pass2(string id, string ids_issue_ent_id, string fb_dtsg, string jazoest, string uid,string cookie)
        {
            return await _appealCheckService.Khang_buoc_1_pass2(id, ids_issue_ent_id, fb_dtsg, jazoest, uid, cookie);
        }
        [HttpPost("Khang_buoc_2")]
        public async Task<object> Khang_buoc_2(string id, string fb_dtsg, string jazoest, string uid, string cookie)
        {
            return await _appealCheckService.Khang_buoc_2(id,fb_dtsg, jazoest, uid, cookie);
        }
        [HttpPost("Khang_buoc_2bm")]
        public async Task<object> Khang_buoc_2bm(string id, string fb_dtsg, string jazoest, string uid, string cookie)
        {
            return await _appealCheckService.Khang_buoc_2bm(id,fb_dtsg, jazoest, uid, cookie);  
        }

        //Todo
        [HttpGet("get-account-die")]
        public async Task<List<AppealCheckAccountDTO>> GetAccountDie(string accessTokenInfo, string cookie)
        {
            var result = await _appealCheckService.GetAccountDie( accessTokenInfo,  cookie);
            return result;
        }
        //Todo
        [HttpGet("get-bm-die")]
        public async Task<List<AppealCheckBMDTO>> GetBMDie(string accessTokenInfo, string cookie)
        {
            var result = await _appealCheckService.GetBMDie( accessTokenInfo,  cookie);
            return result;
        }
        //Todo
        [HttpGet("get-page")]
        public async Task<List<AppealCheckPageDTO>> GetPage(string accessTokenInfo, string cookie, string id, string fb_dtsg, string jazoest)
        {
            var result = await _appealCheckService.GetPage( accessTokenInfo,  cookie,  id,  fb_dtsg,  jazoest);
            return result;
        }
    }
}
