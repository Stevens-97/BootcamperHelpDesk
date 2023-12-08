using bootcamper_helpdesk.Models;
using Microsoft.AspNetCore.Mvc;

namespace bootcamper_helpdesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Set the API route
        [HttpGet("{id}")]
        // Make a function, that is async task then uses Dto as types
        public async Task<ActionResult<ServiceResponse<GetUserResponseDto>>> GetUser(int id)
        {
            var response = await _userService.GetUser(id);

            if (response == null)
            {
                return NotFound(response);

            }
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDto>>> AddUser(AddUserRequestDto newUser)
        {
            var response = await _userService.AddUser(newUser);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDto>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDto>>> UpdateUser(UpdateUserRequestDto updatedUser)
        {
            var response = await _userService.UpdateUser(updatedUser);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
