using BusinessLayer.ComputerService;
using BusinessLayer.Models;
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
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpPost]
        public ActionResult<string> AddManufacturer(ComputerManufacturerDto computerManufacturer)
        {
            if(computerManufacturer.ManufacturerName != null)
            {
                return _computerService.AddManufacturer(computerManufacturer);
            }
            return BadRequest("You've tried to add an invalid data!");
        }

        [HttpGet]
        public ActionResult<List<ComputerManufacturerDto>> GetManufacturers()
        {
            return _computerService.GetComputerManufacturers();
        }

        [HttpDelete]
        public ActionResult<bool> RemoveManufacturer(string id)
        {
            var isSuccess = _computerService.DeleteManufacturer(id);
            if (isSuccess)
                return Ok();
            return BadRequest($"A manufacturer with {id} id doesn't exist!");
        }

    }
}
