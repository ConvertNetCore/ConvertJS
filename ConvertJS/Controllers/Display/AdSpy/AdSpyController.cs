using ConvertJS.DTOs.ResponseDTO;
using ConvertJS.Infras.Constants;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AdSpyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace ConvertJS.Controllers.Display.AdSpy
{
    public class AdSpyController : Controller
    {
        private readonly ILogger<AdSpyController> _looger;
        private readonly IAdSpyService _adSpyService;
        private readonly IAccountService _accountService; 
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMemoryCache _memoryCache;
        public AdSpyController(ILogger<AdSpyController> looger, IAdSpyService adSpyService, IAccountService accountService, IHttpContextAccessor httpContext, IMemoryCache memoryCache)
        {
            _looger = looger;
            _adSpyService = adSpyService;
            _accountService = accountService;
            _httpContext = httpContext;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var adspy = _memoryCache.Get("AdsSpyPosts") as List<AdSpyPostDTO>;
            return View(adspy);
        }
        public async Task<IActionResult> Search(string keyword)
        {
            string cookie = Request.Cookies["cookie"];
            string accessToken = Request.Cookies["accessToken"];
            string fb_dtsg = Request.Cookies["fb_dtsg"];
            string id_user = Request.Cookies["id_user"];
            if (id_user == null)
            {
                var listUser = await _accountService.AdAccount(accessToken, cookie);
                id_user = listUser.FirstOrDefault().Users.FirstOrDefault().UserId;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("id_user", id_user, options);
            }
            var AdsSpyPosts = await _adSpyService.Search(keyword, null, id_user, fb_dtsg, cookie);

            _memoryCache.Set("AdsSpyPosts", AdsSpyPosts);
            return RedirectToAction("Index");
        }
        public IActionResult AddPost(string postId)
        {
            var adspy = _memoryCache.Get("AdsSpyPosts") as List<AdSpyPostDTO>;
            var saveItem = adspy.FirstOrDefault(e => e.Id == postId);
            if(saveItem != null)
            {
                var saveItems = _memoryCache.Get("AdsSpySavePosts") as List<AdSpyPostDTO>;
                if(saveItems == null) { saveItems = new List<AdSpyPostDTO>(); }
                if(!saveItems.Contains(saveItem)) saveItems.Add(saveItem);
                _memoryCache.Set("AdsSpySavePosts", saveItems);
            }
            return RedirectToAction("Index");
        }
    }
}
