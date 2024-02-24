using Microsoft.EntityFrameworkCore;
using productSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// �t�m DbContext
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

var app = builder.Build();

// ���ո�Ʈw�s��
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<NorthwindContext>();
        context.Database.OpenConnection();
        Console.WriteLine("��Ʈw���\�s��");
        context.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"��Ʈw�s������: {ex.Message}");
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
