using ModelsLayer.DTOs;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserDAL
    {
        User SignUp(User userRequest);
        User Login(User userLoginRequest);
    }
}
