using Microsoft.EntityFrameworkCore;
using MyStor.Core.Contracts.Categories;
using MyStor.Core.Contracts.Orders;
using MyStor.Core.Contracts.Payments;
using MyStor.Core.Contracts.Products;
using MyStor.EndPoints.WebUI.Models.Carts;
using MyStor.Infrastructures.DAL.Categories;
using MyStor.Infrastructures.DAL.Commons;
using MyStor.Infrastructures.DAL.Orders;
using MyStor.Infrastructures.DAL.Products;
using MyStor.Services.ApplicationServices.Payments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped(sr => SessionCart.GetCart(sr));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ProductRepository, EfProductRepository > ();
builder.Services.AddScoped<CategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<OrderRepository, EfOrderRepository> ();
builder.Services.AddScoped<PaymentService, PayIrPaymentServices>();
builder.Services.AddDbContext<MystorContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("storeDb")));
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
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default1",
    pattern: "{category}/Page{pageNumber:int}",
    defaults: new { controller = "Product", action = "List"});

app.MapControllerRoute(
    name: "default2",
    pattern:"Page{pageNumber:int}",
    defaults: new { controller = "Product", action="List", productPage = 1 });

app.MapControllerRoute(
    name: "default3",
    pattern: "{category}",
    defaults: new { controller = "Product", action = "List", productPage = 1 });

app.MapControllerRoute(
    name: "default4",
    pattern: "",
    defaults: new { controller = "Product", action = "List", productPage = 1 });

app.MapControllerRoute(
    name: "default5",
    pattern: "{controller=Product}/{action=List}/{id?}");
app.Run();
