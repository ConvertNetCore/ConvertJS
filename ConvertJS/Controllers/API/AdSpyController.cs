using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AdSpyServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.API1
{
    [Route("[controller]")]
    [ApiController]
    public class AdSpyController : ControllerBase
    {
        private readonly IAdSpyService _adSpyService;
        public AdSpyController(IAdSpyService adSpyService)
        {
            _adSpyService = adSpyService;
        }
        //Todo
        [HttpPost("search")]
        public async Task<List<AdSpyPostDTO>> Search(string keyword, string forward_cursor, string user_id, string fb_dtsg, string cookie)
        {
;
            return await _adSpyService.Search( keyword,  forward_cursor,  user_id,  fb_dtsg,  cookie);

        }
    }
}
