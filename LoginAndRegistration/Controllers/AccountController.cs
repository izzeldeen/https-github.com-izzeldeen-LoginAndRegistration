using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public static IWebHostEnvironment _environment;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager , SignInManager<User> siginInManager , ITokenService tokenService , IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = siginInManager;
           _tokenService = tokenService;
            _environment = webHostEnvironment;
        }
        [Produces("application/json")]
        [HttpPost]
        public string Post([FromForm]ProductsDto product)
        {
           
            try
            {
                if(product.files.Length > 0)
                {
                    string path = _environment.WebRootPath + "\\images\\";
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + product.files.FileName))
                    {
                        product.files.CopyTo(fileStream);
                        return "uploaded";
                    }
                }
                else
                {
                    return "Not Uploaded";
                }

                
            }
            catch(Exception ex)
            {
                return "File is empty";
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();
            var NewUser = new UserDto { Email = user.Email, UserName = user.UserName, Token = _tokenService.CreateToken(user) };
            return NewUser;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto RegisterDto)
        {
            var user = await _userManager.FindByEmailAsync(RegisterDto.Email);
            if (user != null) return Ok("Email already exisit");
            var NewUser = new User() { Email = RegisterDto.Email, UserName = RegisterDto.UserName };
            var CreateUser = await _userManager.CreateAsync(NewUser, RegisterDto.Password);
            if (CreateUser == null) return Unauthorized();
            return Ok(new UserDto() { Email = RegisterDto.Email, UserName = RegisterDto.UserName, Token = _tokenService.CreateToken(user) });
        }

        [HttpGet("Auth")]
        [Authorize]
        public string TestAuth()
        {
            return "Authentication is False";
        }


        public class FIleUploadAPI
        {
            public IFormFile files { get; set; }
        }

        [HttpPost("UploadImages")]
        public async Task<string> Post([FromForm] FIleUploadAPI files)
        {
            if (files.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + files.files.FileName))
                    {
                        files.files.CopyTo(filestream);
                        filestream.Flush();
                        return "\\uploads\\" + files.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }

        }
    }
}
