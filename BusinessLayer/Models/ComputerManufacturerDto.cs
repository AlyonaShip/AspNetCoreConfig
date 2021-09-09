using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class ComputerManufacturerDto
    {
        public string Id { get; set; }
        public string ManufacturerName { get; set; }
        public List<ComputerModelDto> ComputerModels { get; set; }
    }
}
