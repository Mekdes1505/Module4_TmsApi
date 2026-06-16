using Microsoft.AspNetCore.Mvc;

namespace TmsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingUserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            if (!Request.Headers.ContainsKey("X-Training-User"))
                return Unauthorized("Missing training user header.");

            var user = Request.Headers["X-Training-User"].ToString();
            return Ok($"Authenticated training user: {user}");
        }
    }
}
