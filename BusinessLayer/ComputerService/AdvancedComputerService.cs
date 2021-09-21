using BusinessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.ComputerService
{
    public class AdvancedComputerService : IComputerService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public AdvancedComputerService(IApplicationDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public string AddManufacturer(CompManufacturerDto compManufacturer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteManufacturer(string id)
        {
            throw new NotImplementedException();
        }

        public List<CompManufacturerDto> GetCompManufacturers()
        {
            _logger.LogInformation("AdvancedComputerService: GetCompManufacturers");
            var manufacturers = _dbContext.CompManufacturers.Include(c => c.CompModels).ToList();
            var resultList = new List<CompManufacturerDto>();
            foreach (var manufacturer in manufacturers)
            {
                resultList.Add(new CompManufacturerDto
                {
                    ManufacturerName = manufacturer.ManufacturerName,
                    CompModels = manufacturer?.CompModels?.Select(model => new CompModelDto
                    {
                        ModelName = model.ModelName
                    }).ToList()
                });
            }
            return resultList;
        }
    }
}
