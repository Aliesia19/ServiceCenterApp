using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;

var builder = WebApplication.CreateBuilder(args);

// ========================
// DATABASE (EF CORE)
// ========================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// ========================
// MVC
// ========================
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ========================
// HTTP PIPELINE
// ========================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ========================
// ROUTES
// ========================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();