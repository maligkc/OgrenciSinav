using BusinessLayer;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OgrenciContext>(options =>
options.UseSqlServer("Server=MEMO\\SQLEXPRESS;Database=DbSinavOgrenci;Trusted_Connection=True;TrustServerCertificate=True;"));
// options.UseSqlServer("Server=MEMO\\SQLEXPRESS\\MSSQLLocalDB;Database=DbSinavOgrenci;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<NotlarRepository>();
builder.Services.AddScoped<NotService>();






// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notlar}/{action=Index}/{id?}");

app.Run();
