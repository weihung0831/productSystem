using Microsoft.EntityFrameworkCore;
using productSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 配置 DbContext
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

var app = builder.Build();

// 測試資料庫連接
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<NorthwindContext>();
        context.Database.OpenConnection();
        Console.WriteLine("資料庫成功連接");
        context.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"資料庫連接失敗: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
