using BussinessLogicLayer.Interface;
using ModelsLayer.DTOs;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Service
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserBLL()
        {
            _userDAL = new UserDAL();
        }
        
        public User Login(User userLoginRequest)
        {           
            return _userDAL.Login(userLoginRequest);
        }

        public User SignUp(User userRequest)
        {
            return _userDAL.SignUp(userRequest);
        }
    }
}
