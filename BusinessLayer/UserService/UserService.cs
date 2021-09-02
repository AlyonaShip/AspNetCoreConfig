using BusinessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.UserService
{
    public class UserService : IUserService
    {
        private IApplicationDbContext _dbContext;
        public UserService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User user)
        {
            var userToAdd = new DataAccessLayer.Entities.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _dbContext.Users.Add(userToAdd);
            _dbContext.SaveChanges();
            return user;                   
        }

        public bool Delete(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id.ToString() == id);            
            if(user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public User EditUser(User user)
        {
            var userToEdit = _dbContext.Users.FirstOrDefault(u => u.Id.ToString() == user.Id);
            if(userToEdit != null)
            {
                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;           
                _dbContext.Users.Update(userToEdit);
                _dbContext.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetAll()
        {
            var users = _dbContext.Users.ToList();
            var userResult = new List<User>();
            foreach (var user in users)
            {
                var mappedUser = new User { FirstName = user.FirstName, LastName = user.LastName };
                userResult.Add(mappedUser);
            }
            return userResult;
        }

        public User GetById(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id.ToString() == id);
            if (user != null)
            {
                var foundUser = new User
                {
                    Id = user.Id.ToString(),
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };               
                return foundUser;
            }
            else
            {
                return null;
            }
        }
    }
}
