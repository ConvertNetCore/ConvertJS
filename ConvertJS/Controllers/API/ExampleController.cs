using Microsoft.AspNetCore.Mvc;

namespace ConvertJS.Controllers.API
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
