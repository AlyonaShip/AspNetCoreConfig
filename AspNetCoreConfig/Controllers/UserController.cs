using BusinessLayer.Models;
using BusinessLayer.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return _userService.GetAll();
        }
        [HttpGet("user/{id}")]
        public ActionResult<User> GetUser(string id)
        {
            var userFound = _userService.GetById(id);
            if(userFound != null)
            {
                return userFound;
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            return _userService.AddUser(user);
        }
        [HttpPut]
        public ActionResult<User> EditUser(User user)
        {
            var userEdited= _userService.EditUser(user);
            if (userEdited != null)
            {
                return userEdited;
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            var isSuccess = _userService.Delete(id);
            if(isSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
