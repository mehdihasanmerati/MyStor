using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStor.Core.Contracts.Categories;
using MyStor.Core.Contracts.Orders;
using MyStor.Core.Contracts.Products;
using MyStor.EndPoints.AdminPanel.Models.Account;
using MyStor.Infrastructures.DAL.Categories;
using MyStor.Infrastructures.DAL.Commons;
using MyStor.Infrastructures.DAL.Orders;
using MyStor.Infrastructures.DAL.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<OrderRepository, EfOrderRepository>();
builder.Services.AddScoped<ProductRepository, EfProductRepository>();
builder.Services.AddScoped<CategoryRepository, EfCategoryRepository>();
builder.Services.AddDbContext<MystorContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("storeDb")));
builder.Services.AddDbContext<AppIdentityDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("storeUserDb")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
