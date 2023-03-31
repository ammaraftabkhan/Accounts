using Accounts.Common.Response_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Accounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        public LoginController(
            UserManager<IdentityUser<int>> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IConfiguration configuration,
            IJwtService jwtService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _jwtService = jwtService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] VM_UserLogin login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user,login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };
                foreach (var userRole in userRoles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = _jwtService.GetToken(authClaim);
                return Ok(new { token =new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    userid= user.Id
                    
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] VM_UserRegistraion model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status409Conflict, new IdResponse { Status = "Error", Message = "User already exists!" });

            IdentityUser<int> user = new()
            {
                Email = model.email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = model.Phonenumber,
                
                
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new IdResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new IdResponse { Status = "Success", Message = "User created successfully!" });
        }
        //private JwtSecurityToken GetToken(List<Claim> authClaims)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:ValidIssuer"],
        //        audience: _configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddHours(3),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    return token;
        //}
    }
}
