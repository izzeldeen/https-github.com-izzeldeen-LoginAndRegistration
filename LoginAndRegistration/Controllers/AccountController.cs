using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Dto;
using Services.IServices;

namespace LoginAndRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager , SignInManager<User> siginInManager , ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = siginInManager;
           _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await  _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password , false);
            if (!result.Succeeded) return Unauthorized();
            var NewUser = new UserDto { Email = user.Email, UserName = user.UserName , Token = _tokenService.CreateToken(user) };
            return NewUser;
         }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto RegisterDto)
        {
            var user = await _userManager.FindByEmailAsync(RegisterDto.Email);
            if (user != null) return Ok("Email already exisit");
            var NewUser = new User() { Email = RegisterDto.Email, UserName = RegisterDto.UserName };
            var CreateUser = await _userManager.CreateAsync(NewUser , RegisterDto.Password);
            if (CreateUser == null) return Unauthorized();
            return Ok(new UserDto() { Email = RegisterDto.Email, UserName = RegisterDto.UserName, Token = _tokenService.CreateToken(user) });
        }

        [HttpGet("Auth")]
        [Authorize]
        public string TestAuth()
        {
            return "Authentication is False";
        }
    }
}
