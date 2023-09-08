using ConvertJS.Infras.Constants;
using ConvertJS.Services.AdSpyServices;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.Display.AdSpy
{
    public class AdSpyController : Controller
    {
        private readonly ILogger<AdSpyController> _looger;
        private readonly IAdSpyService _adSpyService;
        public AdSpyController(ILogger<AdSpyController> looger, IAdSpyService adSpyService)
        {
            _looger = looger;
            _adSpyService = adSpyService;
        }

        public async Task<IActionResult> Index()
        {
            var AdsSpyPosts = await _adSpyService.Search("", "", "", "", "");
            ViewData[KeyTranfer.ADS_SPY] = AdsSpyPosts;
            return View();
        }
    }
}
