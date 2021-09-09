using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ComputerService
{
    public interface IComputerService
    {
        string AddManufacturer(CompManufacturerDto compManufacturer);
        List<CompManufacturerDto> GetCompManufacturers();
        bool DeleteManufacturer(string id);
    }
}
