using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pri.PE_Milan_Cheraft.Api.Dtos.Users;
using Pri.PE_Milan_Cheraft.Api.Extensions;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Models.Results;
using Pri.PE_Milan_Cheraft.Core.Models.Users;
using Pri.PE_Milan_Cheraft.Core.Services.Exercises;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Text;

namespace Pri.PE_Milan_Cheraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequestDto loginDto)
        {
            var loginModel = new UserLoginRequestModel
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            };
            var result = await _userService.LoginAsync(loginModel);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.Messages);
            }

            return Ok(new TokenDto { BearerToken = result.Token });
        }
        [HttpGet]
        [Authorize(Policy ="Trainer")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users.Value.MapToDto());
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequestDto registerDto)
        {
            var registerModel = new UserCreateRequestModel
            {
                Email = registerDto.Email,
                BirthDate = registerDto.BirthDate,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Weight = registerDto.Weight,
                Length = registerDto.Length,
                DisplayName = registerDto.DisplayName,
                Password = registerDto.Password,
                Username = registerDto.Email,
                
            };
            var result = await _userService.RegisterAsync(registerModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Messages);
            }
            return Ok(result.Messages);
        }
        [HttpGet("Search/{email}")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            if (result.IsSuccess)
            {
                return Ok(result.Value.MapToDto());
            }
            return Ok(result.Errors);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UserUpdateRequestModel model)
        {
            var result = await _userService.Update(model);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
