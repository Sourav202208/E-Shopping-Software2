using HealthDemo.Data.Entities;
//using HealthDemo.Data.Identity;
using HealthDemo.Data.ModelDbContext;
using HealthDemo.Factory.Patients;
using HealthDemo.Service.PatientService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
//<--Serilog-->
var logger = new LoggerConfiguration()
    .WriteTo.File("ACLogs/AC.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Warning()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//builder.Services.globalization culture = "en-GB", uiCulture="en-GB";
builder.Services.AddDbContext<ApplicationDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<HealthDemoWebAppContext>(options => options.UseSqlServer(connectionString));


//builder.Services.AddDefaultIdentity<HealthDemoWebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<HealthDemoWebAppContext>();



//builder.Services.AddDefaultIdentity<HealthDemoWebAppUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HealthDemoWebAppContext>();
//<<--AutoMapper-->

builder.Services.AddAutoMapper(typeof(Program));
//<---RoleDeclared-->
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("DoctorPolicy", policy =>
//        policy.RequireRole("Doctor"));
//});

//<--Password Validation-->
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//});
//Factory mapping
builder.Services.AddTransient<IPatientFactory, PatientFactory>();
//Service Mapping
builder.Services.AddScoped<IPatientService,PatientService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();;
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
