using Microsoft.AspNetCore.Mvc;

namespace Project_2353.WebAPI.Controllers
{
     
#if DEBUG
    [Route("api/[controller]")]
#else
    [Route("[controller]")]
#endif
    
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        [Route("heart-beat")]
        [HttpGet]
        public IActionResult HeartBeat()
        {
            return new JsonResult(new { success = true });
        }

        [NonAction]
        public IActionResult Json(object o)
        {
            return new JsonResult(o);
        }
    }
}