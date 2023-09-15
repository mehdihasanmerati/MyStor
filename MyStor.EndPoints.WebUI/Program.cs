using Microsoft.EntityFrameworkCore;
using MyStor.Core.Contracts.Products;
using MyStor.Infrastructures.DAL.Commons;
using MyStor.Infrastructures.DAL.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddScoped<ProductRepository, EfProductRepository > ();
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

app.MapControllerRoute(
    name: "default1",
    pattern:"Page{pageNumber:int}",
    defaults: new { controller = "Product", action="List", productPage=1});
app.MapControllerRoute(
    name: "default2",
    pattern: "{controller=Product}/{action=List}/{id?}");

app.Run();
