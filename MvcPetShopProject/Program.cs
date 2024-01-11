using Microsoft.EntityFrameworkCore;
using MvcPetShopProject.Data;
using MvcPetShopProject.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetShopContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=PetShop}/{action=Home}/{id?}");

app.Run();