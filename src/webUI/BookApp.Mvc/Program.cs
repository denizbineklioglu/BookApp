using BookApp.Entities;
using BookApp.Infrastructure.Context;
using BookApp.Infrastructure.Repositories;
using BookApp.Mvc.Extensions;
using BookApp.Mvc.Models;
using BookApp.Services;
using BookApp.Services.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInjections();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(10);
});

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<BookDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BookDbContext>();



builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/User/Login");
	opt.LogoutPath = new PathString("/User/LogOut");
    opt.AccessDeniedPath = new PathString("/User/AccesDenied");

	opt.Cookie = new()
	{
		Name = "IdentityCookie",
		HttpOnly = true,
		SecurePolicy = CookieSecurePolicy.Always
	};
    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.AddAuthentication();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//				.AddCookie(opt =>
//				{
//					opt.LoginPath = "/User/Login";
//					opt.LogoutPath = "/User/LogOut";
//					opt.ReturnUrlParameter = "yonlendir";
//					opt.AccessDeniedPath = "/User/AccesDenied";
//				});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
