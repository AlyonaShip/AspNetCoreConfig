using BusinessLayer.Models;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BusinessLayer.UserService
{
    public class UserService : IUserService
    {
        private IApplicationDbContext _dbContext;
        private readonly SqlConnection _sqlConn;
        public UserService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _sqlConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; database=UserInfo; Integrated Security=True");
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

        public User FindByName(string userName)
        {
            var stopWatchStoreProc = new Stopwatch();
            var stopWatchLinq = new Stopwatch();
            double elapsedSP = 0, elapsedLinq = 0;
            var cmd = new SqlCommand("FinUser", _sqlConn) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@NameToSearch", userName);
            
            stopWatchStoreProc.Start();
            _sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (dr.Read())
            {
                users.Add(new User 
                { 
                    FirstName = dr.GetString(1), 
                    LastName = dr.GetString(2)
                });
            }
            stopWatchStoreProc.Stop();
            elapsedSP = stopWatchStoreProc.Elapsed.TotalMilliseconds;

            _sqlConn.Close();

            stopWatchLinq.Start();
            var userViaLinq = _dbContext.Users.Where(u => u.FirstName == userName).ToList();
            stopWatchLinq.Stop();
            elapsedLinq = stopWatchLinq.Elapsed.TotalMilliseconds;

            var firstUser = userViaLinq.FirstOrDefault();

            return new User { FirstName = firstUser.FirstName, LastName = firstUser.LastName };
        }

        public List<User> GetAll()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var users = _dbContext.Users.Where(u => (u.FirstName.StartsWith("John_11111") 
            || u.FirstName.StartsWith("Sam_11111")) 
            && (u.LastName.StartsWith("Doe_11111") 
            || u.LastName.StartsWith("Smith_11111"))).OrderBy(u => u.LastName).ToList();
            stopWatch.Stop();

            //331 msec - without index
            //4 msec - without index
            var elapsedTime = stopWatch.Elapsed.TotalMilliseconds;

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
