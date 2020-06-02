using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPhone.Entities;

namespace WebPhone.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Shop> Shops { get; set; }
    }
}
