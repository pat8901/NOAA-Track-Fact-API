// using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

// Satellite Database minimal apis
// app.MapGet("/satellite", async (SatelliteContext db) => await db.Satellites.ToListAsync());

// app.MapGet("/satellite/{name}", async (string name, SatelliteContext db) =>
// await db.Satellites.SingleOrDefaultAsync(x => x.Name == name));

// app.MapPost("/satellite", async (SatelliteContext db, Satellite satellite) =>
// {
//     db.Satellites.Add(satellite);
//     await db.SaveChangesAsync();
//     return Results.Ok(await db.Satellites.ToListAsync());
// });

// app.MapDelete("/satellite/{name}", async (string name, SatelliteContext context) =>
// {
//     var satellite = await context.Satellites.SingleOrDefaultAsync(x => x.Name == name);
//     if (satellite == null)
//     {
//         return Results.NotFound("Entry not found!");
//     }
//     context.Satellites.Remove(satellite);
//     await context.SaveChangesAsync();
//     return Results.Ok();
// });

app.Run();
