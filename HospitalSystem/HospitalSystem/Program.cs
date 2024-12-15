using HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Načtení připojovacího řetězce
string connectionString = builder.Configuration.GetConnectionString("MySQL");

// Registrace DbContext s použitím připojovacího řetězce
builder.Services.AddDbContext<HospitalSystemDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30))));

builder.Services.AddControllersWithViews();

// Registrace služeb aplikační vrstvy
builder.Services.AddScoped<IPatientAppService, PatientAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();