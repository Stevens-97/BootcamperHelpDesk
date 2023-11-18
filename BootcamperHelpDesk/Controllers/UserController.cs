using Microsoft.AspNetCore.Mvc;

namespace bootcamper_helpdesk.Controllers
{
    public class UserController : ControllerBase
    {
        // Set the http request

        // Set the API route
        [HttpGet("api/[controller]")]
        // Make a function, that is async task then uses Dto as types
        public Task<> GetUser()
        {
            return Ok();
        }
    }
}
