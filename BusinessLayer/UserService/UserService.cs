using BusinessLayer.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.UserService
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _dbContext;
        public UserService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetAll()
        {
            var users = _dbContext.Users.ToList();
            var userResult = new List<User>();
            foreach (var user in users)
            {
                var mappedUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                userResult.Add(mappedUser);
            }
            return userResult;
        }
    }
}
