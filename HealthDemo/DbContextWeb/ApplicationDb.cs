using HealthDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Data.ModelDbContext
{
    public class ApplicationDb: DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {


        }
        public DbSet<Employee> Employees { get; set; }
    }
}
