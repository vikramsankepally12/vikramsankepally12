using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HospitalManagementDbContext _context;

        public LoginController(HospitalManagementDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Username and password are required.");
            }
            var user =  _context.HospitalRegistrations.SingleOrDefaultAsync(u => u.UserName == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

           // return Ok("Login successful!");

           

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sec2342342342342342323423333333333333333333333222222222222222retKeyerwrewwerwe"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                     new Claim(ClaimTypes.Name, loginRequest.Username) }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = credentials,
                    Issuer = "MyApp",
                    Audience = "MyAppUsers"
                };

                   var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);           

         
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new { Token = tokenString });
            }
           
        }   
           
             
    }
   


