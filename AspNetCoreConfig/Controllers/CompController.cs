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
    public class CompController : ControllerBase
    {
        private readonly IComputerService _computerService;
        public CompController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpPost]
        public ActionResult<string> AddManufacturer(CompManufacturerDto compManufacturer)
        {
            if(compManufacturer.ManufacturerName != null)
            {
                return _computerService.AddManufacturer(compManufacturer);
            }
            return BadRequest("You've tried to add an invalid data");
        }

        [HttpGet]
        public ActionResult<List<CompManufacturerDto>> GetCompManufacturers()
        {
            return _computerService.GetCompManufacturers();
        }

        [HttpDelete]
        public ActionResult<bool> RemoveManufacturer(string id)
        {
            var isSuccess = _computerService.DeleteManufacturer(id);
            if (isSuccess)
                return Ok();
            return BadRequest($"A manufacturer with {id} id doesn't exist");
        }
    }
}
