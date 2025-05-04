using AuthApi.Application.Dtos;
using AuthApi.Application.Interfaces;
using eCommerce.SharedLibrary.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUser userInterface) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<Response>> Register([FromBody]AppUserDto appUserDto)
        {
            // Check model state is all data annotations are passed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert to entity
            var response = await userInterface.Register(appUserDto);
            return response?.Flag is true ? Ok(response) : BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response>> Login([FromBody] LoginDto loginDto)
        {
            // Check model state is all data annotations are passed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert to entity
            var response = await userInterface.Login(loginDto);
            return response?.Flag is true ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response>> Login([FromRoute(Name = "id")] int id)
        {
            // Check model state is all data annotations are passed
            if (id <= 0)
            {
                return BadRequest("Invalid User id");
            }

            // Convert to entity
            var response = await userInterface.GetUser(id);
            return response.Email is not null ? Ok(response) : BadRequest(Request);
        }
    }
}
