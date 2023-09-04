using ConvertJS.DTOs;
using ConvertJS.Services.RulesServices;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ConvertJS.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        [HttpGet("check_live_token")]
        public async Task<object> checkLiveToken(string accessTokenInfo,string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
               RulesService rulesService = new RulesService();
                return await rulesService.check_live_token(accessTokenInfo, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("information")]
        public async Task<object> Information(string cookie)
        {
            RulesService rulesService = new RulesService();
            return await rulesService.Information(cookie);
        }
        [HttpGet("get_all_camp_from_id_tkqc")]
        public async Task<object> getAllCampFromIdTkqc(string accessTokenInfo,string idqc, string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //idqc = "1290353111536829";
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                RulesService rulesService = new RulesService();
                return await rulesService.get_all_camp_from_id_tkqc(accessTokenInfo,idqc, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("get_all_adset_from_camp")]
        public async Task<object> get_all_adset_from_camp(string accessTokenInfo, string id_camp, string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                RulesService rulesService = new RulesService();
                return await rulesService.get_all_adset_from_camp(accessTokenInfo,id_camp, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }
        [HttpGet("get_all_ads_from_adset")]
        public async Task<object> get_all_ads_from_adset(string accessTokenInfo, string id_adset, string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            if (accessTokenInfo != null)
            {
                RulesService rulesService = new RulesService();
                return await rulesService.get_all_ads_from_adset(accessTokenInfo,id_adset, cookie);
            }
            else
            {
                return new { Error = "Token is not null" };
            }
        }

    }
}


