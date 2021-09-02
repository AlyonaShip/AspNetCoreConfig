using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.UserService
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(string id);
        User AddUser(User user);
        User EditUser(User user);
        bool Delete(string id);

    }
}
