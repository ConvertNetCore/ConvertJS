using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers
{
    public class ExampleController : BaseAPIController
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok("Example Api");
        }
    }
}
