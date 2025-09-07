using HealthDemo.Data.Entities;

using HealthDemo.Data.ModelDbContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HealthDemo.Data.ModelDbContext
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }

        public DbSet<Event> Events { get; set; }

    }
}
