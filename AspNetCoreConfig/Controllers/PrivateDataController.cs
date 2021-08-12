using BusinessLayer.Model;
using BusinessLayer.UserService;
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
        [Route("get-user")]
        public List<User> GetAllusers()
        {
            return _userService.GetAll();
        }
    }
}
