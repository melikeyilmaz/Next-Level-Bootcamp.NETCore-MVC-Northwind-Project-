using Odev_1_MelikeYilmaz.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "orders",
    pattern: "Orders/{action=List}/{employeeId?}",
    defaults: new { controller = "Orders", action = "List" });

app.Run();
