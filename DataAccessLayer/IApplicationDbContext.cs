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
    }
}
