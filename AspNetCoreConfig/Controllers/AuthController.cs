using AspNetCoreConfig.Models;
using BusinessLayer.ComputerService;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace AspNetCoreConfig.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ComputerService _computerService;
        public AuthController(IApplicationDbContext applicationDbContext)
        {
            _computerService = new ComputerService(applicationDbContext);
        }

        private List<LoginModel> people = new List<LoginModel>
        {
            new LoginModel { UserName ="Tyler", Password="22222", Role = "Manager" },
            new LoginModel { UserName ="Marla", Password="33333", Role = "Editor" }
        };

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel user)
        {
            var manufacturers = _computerService.GetComputerManufacturers();

            var identity = GetIdentity(user);
            if (user == null)
            {
                return BadRequest("Invalide data");
            }
            if (identity != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44382",
                    audience: "https://localhost:44382",
                    claims: identity.Claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        private ClaimsIdentity GetIdentity(LoginModel user)
        {
            LoginModel person = people.FirstOrDefault(p => p.UserName == user.UserName && p.Password == user.Password);
            if(person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }


    }
}
