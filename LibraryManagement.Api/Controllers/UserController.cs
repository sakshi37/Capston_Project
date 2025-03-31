using AutoMapper;
using LibraryManagement.Api.DTO;
using LibraryManagement.Api.Jwt;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly UserManager<ApplicationUser> _userManager;
        public UserController(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<ApplicationUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                return Ok("Successful");
            }
            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });


        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {

                return Unauthorized(new { Message = "Invalid email or password." });
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password); ;
            if (!isPasswordValid)
            {
                return Unauthorized(new { Message = "Invalid email or password." });

            }
            var accessToken = TokenGenerator.GenrateAccessToken(user);
            return Ok(new { Message = "Successful", AccessToken = accessToken });

        }
    }
}
