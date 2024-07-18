using BussinessLogicLayer.Interface;
using BussinessLogicLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EntityFrameworkCoreDataBaseFirst.Controllers
{
    //[Authorize]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBLL _userBLL;
        private IConfiguration _configuration;// pass it to constractor
        public UserController(IConfiguration configuration)
        {
            _userBLL = new UserBLL();
            _configuration=configuration;
        }
        private string GenarateToken(User user) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],_configuration["Jwt:Audience"],null,
                expires:DateTime.Now.AddMinutes(5),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        [Route("SignUp")]
        public User SignUp([FromBody]User userRequest)
        {
            return _userBLL.SignUp(userRequest);
        }
        /**
         * 	
            Response body
            Download
            {
              "userId": 3,
              "userName": "Chandrashekar",
              "email": "Chandrashekar",
              "phonenumber": 70220,
              "password": "$2a$11$msBEWVbaenTaAf.OwelNaOGv.LACMiJP7XUDpLR53PzrjS6WKUFr6"
             }
        **/
        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public IActionResult Login([FromQuery]User userLoginRequest)
        {
            IActionResult responce = Unauthorized();
            var user = _userBLL.Login(userLoginRequest);
            if (user != null)
            {
                var token = GenarateToken(user);
                responce = Ok(new { token = token });
            }
            return responce;
            //return _userBLL.Login(userLoginRequest);
        }
    }
}
