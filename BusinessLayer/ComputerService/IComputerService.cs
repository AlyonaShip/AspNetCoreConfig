using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ComputerService
{
    public interface IComputerService
    {
        List<ComputerManufacturerDto> GetComputerManufacturers();
        string AddManufacturer(ComputerManufacturerDto computerManufacturer);
        bool DeleteManufacturer(string id);
    }
}
