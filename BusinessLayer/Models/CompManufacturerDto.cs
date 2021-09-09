using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class CompManufacturerDto
    {
        public string Id { get; set; }
        public string ManufacturerName { get; set; }
        public List<CompModelDto> CompModels { get; set; }
    }
}
