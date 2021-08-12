using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ComputerManufacturer> ComputerManufacturers { get; set; }
        public DbSet<ComputerModel> ComputerModels { get; set; }
        public DbSet<ComputerModelTag> ComputerModelTags { get; set; }
    }
}
