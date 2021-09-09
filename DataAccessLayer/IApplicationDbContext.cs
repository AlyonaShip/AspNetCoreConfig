using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CompManufacturer> CompManufacturers { get; set; }
        public DbSet<CompModel> CompModels { get; set; }
        public int SaveChanges();
    }
}
