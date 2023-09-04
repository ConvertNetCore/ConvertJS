using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AdSpyServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class AdSpyController
    {
        [HttpPost("search")]
        public async Task<object> Search(string keyword, string forward_cursor, string cookie)
        {
            //var accessTokenInfo = await requestHelper.GetToken();
            //accessTokenInfo = "EAABsbCS1iHgBOwjzX4NUE2yAQOoI9ZAFRjbo5Nr5oCQhNS2BrByRNl3zmHqJH2J8RZBz9UcjZBXxzEpH1CeZA0jTK0KtifcFRSs11tz0W7DNjo1I60hNlGjmV2VNZCvW0NKytY6Kf1PstZCcD8iL8i8Oku7VHUyCa0kbfXwMslZAvMTOlORN97uX9855vIhi4BzmGpfQz2MWQZDZD";
            
                AdSpyService adSpyService = new AdSpyService();
                return await adSpyService.Search(keyword,forward_cursor, cookie);
            
        }
    }
}
