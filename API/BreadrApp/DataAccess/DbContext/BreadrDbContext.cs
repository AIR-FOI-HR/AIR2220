using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public class BreadrDbContext : DbContext
    {
        public BreadrDbContext(DbContextOptions<BreadrDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }

    }
}
