//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace HealthDemo.Data.Identity;

//public class HealthDemoWebAppContext : IdentityDbContext<HealthDemoWebAppUser>
//public class HealthDemoWebAppContext 
//{
    
//    //public HealthDemoWebAppContext(DbContextOptions<HealthDemoWebAppContext> options)
//    //    : base(options)
//    //{

//    //}

//    //protected override void OnModelCreating(ModelBuilder builder)
//    //{
//    //    base.OnModelCreating(builder);
//    //    builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());      
//    //}
//    public DbSet<HealthDemoWebAppUser> HealthDemoWebAppUsers { get; set; }
//}

//public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<HealthDemoWebAppUser>
//{
//    public void Configure(EntityTypeBuilder<HealthDemoWebAppUser> builder)
//    {

//        builder.Property(a => a.Firstname).HasMaxLength(100);
//        builder.Property(a => a.Lastname).HasMaxLength(100);
//        builder.Property(a=>a.Role).HasMaxLength(100);

//    }
//}
