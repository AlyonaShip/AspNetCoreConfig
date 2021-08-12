using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ComputerModelTag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }        
        public string TagInfo { get; set; }
        public string ComputerModelId { get; set; }
        public SalesInfo SalesInfo { get; set; }
        public ComputerModel ComputerModel { get; set; }
    }

    [Owned]
    public class SalesInfo
    {
        public string SalesDepartment { get; set; }
        public string DepartmentLocation { get; set; }
        public string DepartmentZipCode { get; set; }
    }
}
