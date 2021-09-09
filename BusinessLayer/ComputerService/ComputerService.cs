using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.ComputerService
{
    public class ComputerService : IComputerService
    {
        private readonly IApplicationDbContext _dbContext;
        public ComputerService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddManufacturer(CompManufacturerDto compManufacturer)
        {
            var manufacturer = new CompManufacturer
            {
                ManufacturerName = compManufacturer.ManufacturerName
            };
            manufacturer.CompModels = new List<CompModel>();
            foreach (var model in compManufacturer.CompModels)
            {
                manufacturer.CompModels.Add(new CompModel 
                { 
                    ModelName = model.ModelName
                });
            }

            _dbContext.CompManufacturers.Add(manufacturer);
            _dbContext.SaveChanges();
            return manufacturer.Id;
        }

        public bool DeleteManufacturer(string id)
        {
            var manufacturer = _dbContext.CompManufacturers.Include(c => c.CompModels).FirstOrDefault(m => m.Id == id);
            if(manufacturer != null)
            {
                _dbContext.CompManufacturers.Remove(manufacturer);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CompManufacturerDto> GetCompManufacturers()
        {
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
