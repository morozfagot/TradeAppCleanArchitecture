using Microsoft.EntityFrameworkCore;
using TradeApp.Application.AddMediator;
using TradeApp.Domain.Interfaces.InterfacesRepository;
using TradeApp.Infrastructure;
using TradeApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationDependencies();

builder.Services.AddDbContext<TradingDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(TradingDbContext)));
});
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

var app = builder.Build();

await app.SeedAsync();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();