global using BlazingProject.Shared;
global using Microsoft.EntityFrameworkCore;
using BlazingProject.Client.Helpers;
using BlazingProject.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Program(IConfiguration configuration)
//{
//    Configuration = configuration;
//}
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection"))
);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
//builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<IConfiguration>(configuration) ;
builder.Services.AddSingleton<HelperMail>();
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
