using HealthDemo.Model.ApiLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HealthDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly JWTSettingModeVMl _jwtSettingModel;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IConfiguration configuration, IOptions<JWTSettingModeVMl> jwtSettingModel, ILogger<LoginController> logger)
        {
            _configuration = configuration;
            _jwtSettingModel = jwtSettingModel.Value;
            _logger = logger;
        }
        //<--AuthenticateUser-->
        private UsersVM AuthenticateUser(UsersVM user)
        {
            UsersVM _user = null;
            if(user.Username== "Admin" &&  user.Password=="12345")
            {
               _user =  new UsersVM { Username = "Kaushal" };
            }
            return _user;
        }
        //<--Generate Token-->
        private string  GenerateToken(UsersVM user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettingModel.Key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_jwtSettingModel.Issuer, _jwtSettingModel.Audience,
            null, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);                   
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        [AllowAnonymous]
        //<--Login-->
        public IActionResult Login(UsersVM user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if(user_ != null)
            {
                var token= GenerateToken(user_);
                response= Ok(new {token=token});
            }
            return response;
        }
    }
}
