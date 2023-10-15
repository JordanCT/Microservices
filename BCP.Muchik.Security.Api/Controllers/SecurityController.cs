using BCP.Muchik.Security.Application.Dtos;
using BCP.Muchik.Security.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Muchik.Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] UserDto userDto)
        {
            _securityService.SignUp(userDto);
            return Ok();
        }

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody] SignInRequestDto signInRequestDto)
        {
            return Ok(_securityService.SignIn(signInRequestDto));
        }
    }
}
