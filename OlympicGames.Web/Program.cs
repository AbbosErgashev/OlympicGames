using Microsoft.EntityFrameworkCore;
using OlympicGames.Infrastructure.Data;
using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.Repositories;
using OlympicGames.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"))
    .EnableSensitiveDataLogging();
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAreaRepository, AreaRepository>();
builder.Services.AddTransient<IAthleteRepository, AthleteRepository>();
builder.Services.AddTransient<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepostiroy>();
builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IMedalRepository, MedalRepository>();
builder.Services.AddTransient<IOlympicEventRepository, OlympicEventRepository>();
builder.Services.AddTransient<IYearRepository, YearRepository>();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
