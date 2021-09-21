using BusinessLayer.ComputerService;
using BusinessLayer.Lifecycle;
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

        private readonly ITransient _transient_1;
        private readonly ITransient _transient_2;

        private readonly IScoped _scoped_1;
        private readonly IScoped _scoped_2;

        private readonly ISingleton _singleton_1;
        private readonly ISingleton _singleton_2;


        public CompController(IComputerService computerService,
            ITransient transient_1,
            ITransient transient_2,
            ISingleton singleton_1,
            ISingleton singleton_2,
            IScoped scoped_1,
            IScoped scoped_2

            )
        {
            _computerService = computerService;
            _transient_1 = transient_1;
            _transient_2 = transient_2;
            _scoped_1 = scoped_1;
            _scoped_2 = scoped_2;
            _singleton_1 = singleton_1;
            _singleton_2 = singleton_2;
        }

        [HttpGet]
        [Route("display-lifetime")]
        public ActionResult<object> DisplayLifetime()
        {
            var _scopedGuid_1 = _scoped_1.GetGuid();
            var _scopedGuid_2 = _scoped_2.GetGuid();

            var _transientGuid_1 = _transient_1.GetGuid();
            var _transientGuid_2 = _transient_2.GetGuid();

            var _singletonGuid_1 = _singleton_1.GetGuid();
            var _singletonGuid_2 = _singleton_2.GetGuid();

            return new ActionResult<object>(new { _scopedGuid_1, _scopedGuid_2, _transientGuid_1, _transientGuid_2, _singletonGuid_1, _singletonGuid_2 });
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
