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
        public string AddManufacturer(ComputerManufacturerDto computerManufacturer)
        {
            var manufacturer = new ComputerManufacturer
            {
                ManufacturerName = computerManufacturer.ManufacturerName
            };

            manufacturer.ComputerModels = new List<ComputerModel>();
            foreach(var model in computerManufacturer.ComputerModels)
            {
                manufacturer.ComputerModels.Add(new ComputerModel 
                { 
                    ModelName = model.ModelName
                });               
            }

            _dbContext.ComputerManufacturers.Add(manufacturer);
            _dbContext.SaveChanges();

            return manufacturer.Id;

        }

        public bool DeleteManufacturer(string id)
        {
            var manufacturer = _dbContext.ComputerManufacturers.Include(c => c.ComputerModels).FirstOrDefault(m => m.Id == id);
            if(manufacturer != null)
            {
                _dbContext.ComputerManufacturers.Remove(manufacturer);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public List<ComputerManufacturerDto> GetComputerManufacturers()
        {
            var manufacturers = _dbContext.ComputerManufacturers.Include(c => c.ComputerModels ).ToList();
            var resultList = new List<ComputerManufacturerDto>();
            foreach (var manufacturer in manufacturers)
            {
                resultList.Add(new ComputerManufacturerDto
                {
                    ManufacturerName = manufacturer.ManufacturerName,
                    ComputerModels = manufacturer?.ComputerModels?.Select(model => new ComputerModelDto
                    {
                        ModelName = model.ModelName
                    }).ToList()
                });
            }
            return resultList;
        }
    }
}
