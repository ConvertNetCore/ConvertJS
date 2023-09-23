using ConvertJS.DTOs.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ConvertJS.Controllers.Display.AdSpy
{
    public class SaveListAdSpyController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public SaveListAdSpyController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            var adspy = _memoryCache.Get("AdsSpySavePosts") as List<AdSpyPostDTO>;
            return View(adspy);
        }
        public IActionResult DeleteItem(string postId)
        {
            var adspy = _memoryCache.Get("AdsSpySavePosts") as List<AdSpyPostDTO>;
            var saveItem = adspy.FirstOrDefault(e => e.Id == postId);
            if (saveItem != null)
            {
                var saveItems = _memoryCache.Get("AdsSpySavePosts") as List<AdSpyPostDTO>;
                saveItems.Remove(saveItem);
                _memoryCache.Set("AdsSpySavePosts", saveItems);
            }
            return RedirectToAction("Index");
        }
    }
}
