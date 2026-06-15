using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using What_to_Do.DataBaseContext;
using What_to_Do.Helpers;
using What_to_Do.Models.DTOs;
using What_to_Do.Models.Entities;

namespace What_to_Do.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                UserName = registerDTO.Username,
                Password = registerDTO.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User Registered Successfully");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
           var user =  _context.Users.FirstOrDefault(x=>
            x.UserName == loginDTO.Username &&  x.Password == loginDTO.Password);

            if(user == null)
            {
                return Unauthorized();
            }
            var token = JwtHelpers.GenerateToken(_configuration,user.UserName,user.Role);
            return Ok(token);
        }


    }
}
