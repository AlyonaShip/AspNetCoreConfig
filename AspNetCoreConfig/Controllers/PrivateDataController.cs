using BusinessLayer.Models;
using BusinessLayer.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreConfig.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrivateDataController : ControllerBase
    {
        private readonly IUserService _userService;
        public PrivateDataController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "First secred data string", "Second secred data string" };
        }

        [HttpGet]
        [Authorize]
        [Route("get-users")]
        public List<User> GetAllUsers()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        [Route("manager-data")]
        public IEnumerable<string> GetManagersData()
        {
            return new string[] { "GetManagersData()", "Manager Data" };
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        [Route("editor-data")]
        public IEnumerable<string> GetEditorsData()
        {
            return new string[] { "GetEditorsData()", "Editor Data" };
        }       
    }
}
