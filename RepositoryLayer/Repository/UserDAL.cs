using Microsoft.EntityFrameworkCore;
using ModelsLayer.DTOs;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserDAL : IUserDAL
    {
        private readonly UserContext _userContext;
        public UserDAL()
        {
            _userContext = new UserContext();
        }
       
        public User Login(User userLoginRequest)
        {
            var currentUser = _userContext.Users.FirstOrDefault(u => u.Email.Equals(userLoginRequest.Email));
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(userLoginRequest.Password, currentUser.Password);
            if (isValidPassword)
            {
                return currentUser;
            }
            return null;
        }

        public User SignUp(User userRequest)
        {
            userRequest.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
            var addedUser = _userContext.Users.Add(userRequest);
            _userContext.SaveChanges();
            return userRequest;
        }
    }
}
