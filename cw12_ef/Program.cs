using cw12_ef.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var connString = builder.Configuration.GetConnectionString("mysql");
// builder.Services.AddDbContext<BooksContext>(op=>op.UseSqlite(connString));
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();