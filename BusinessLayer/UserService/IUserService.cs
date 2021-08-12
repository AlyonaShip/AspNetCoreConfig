using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.UserService
{
    public interface IUserService
    {
        List<User> GetAll(); 
    }
}
