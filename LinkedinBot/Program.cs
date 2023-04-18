using LinkedinBot.Data;
using LinkedinBot.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conection = builder.Configuration.GetConnectionString("PostgreSQLConnectionString") ?? "";

builder.Services.AddDbContext<LinkedinBotContext>(options => options.UseNpgsql(conection));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILinkedinScraper, LinkedinScraper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
