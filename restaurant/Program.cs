using Microsoft.Extensions.Logging;
using restaurant.Abstraction;
using restaurant.Metier;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Menus du restaurant",
        Version = "v1"
    });
});

builder.Services.AddSingleton<MenuRepository, MenuLocalRepository>();

var app = builder.Build();

Console.WriteLine("Démarrage de l'API");

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var aspNetCoreUrls = configuration["ASPNETCORE_URLS"];
var aspNetCoreHttpPorts = configuration["ASPNETCORE_HTTP_PORTS"];

// Ajoutez ces valeurs aux logs
Console.WriteLine($"ASPNETCORE_URLS: {aspNetCoreUrls}");
Console.WriteLine($"ASPNETCORE_HTTP_PORTS: {aspNetCoreHttpPorts}");


// Configure the HTTP request pipeline.
app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

