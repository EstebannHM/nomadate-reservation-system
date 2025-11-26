using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using nomadate_web.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Step 1 - MVC
builder.Services.AddControllersWithViews();


//Step 2 - DbContext connection string from appsettings.json

builder.Services.AddDbContext<NomadateContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NomadateDD")));

//Step 3 - Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Denied";
});

builder.Services.AddDbContext<NomadateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NomadateDB")));


var app = builder.Build();


//Pipeline

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Step 4 - Authentication then authorization

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
