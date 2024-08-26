using Microsoft.EntityFrameworkCore;
using System.Reflection;
using NOAA_API.Data;
using NOAA_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Setting up user secrets via configuration to keep sensitive information safe in dev environment.
IConfigurationRoot config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.AddUserSecrets(Assembly.GetEntryAssembly()!)
.Build();

// Adding Satellite SQL Server DB service to application
var connection_string = builder.Configuration["satellite_db:c_string"];
builder.Services.AddDbContextFactory<SatelliteDbContext>(options =>
    options.UseSqlServer(connection_string));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal api section
app.MapGet("/hi", () => "Hello!");

//Satellite Database minimal apis
app.MapGet("/satellite", async (SatelliteDbContext db) => await db.Satellites.ToListAsync());

app.MapGet("/satellite/{name}", async (string name, SatelliteDbContext db) =>
await db.Satellites.SingleOrDefaultAsync(x => x.Name == name));

app.MapPost("/satellite", async (SatelliteDbContext db, Satellite satellite) =>
{
    db.Satellites.Add(satellite);
    await db.SaveChangesAsync();
    return Results.Ok(await db.Satellites.ToListAsync());
});

app.MapDelete("/satellite/{name}", async (string name, SatelliteDbContext context) =>
{
    var satellite = await context.Satellites.SingleOrDefaultAsync(x => x.Name == name);
    if (satellite == null)
    {
        return Results.NotFound("Entry not found!");
    }
    context.Satellites.Remove(satellite);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
