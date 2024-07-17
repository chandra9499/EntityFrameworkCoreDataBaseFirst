using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Interface
{
    public interface IUserBLL
    {
        User SignUp(User userRequest);
        User Login(User userLoginRequest);
    }
}
