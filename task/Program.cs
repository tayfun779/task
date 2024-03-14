using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using task.contexts;
using task.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProniaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<AppUser,IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase=true;
    options.Password.RequireLowercase=true;
    options.Password.RequireDigit=true;
    options.Password.RequireNonAlphanumeric=true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);

})
    .AddEntityFrameworkStores<ProniaDbContext>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );


app.UseStaticFiles();
app.Run();
