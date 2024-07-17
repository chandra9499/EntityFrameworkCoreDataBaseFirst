using BussinessLogicLayer.Interface;
using BussinessLogicLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace EntityFrameworkCoreDataBaseFirst.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBLL _userBLL;
        public UserController()
        {
            _userBLL = new UserBLL();
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
        [HttpGet]
        [Route("Login")]
        public User Login([FromQuery]User userLoginRequest)
        {
            return _userBLL.Login(userLoginRequest);
        }
    }
}
