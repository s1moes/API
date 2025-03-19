using API.Models;
using API.Services;
using AutoMapper;
using MongoDB.Driver;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<ICompraAppService, CompraAppService>();



// MongoDB setup
var connectionString = "DbConnection";
var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase("ToDo");
builder.Services.AddSingleton<IMongoDatabase>(database);
builder.Services.AddSingleton<IMongoClient>(mongoClient);

// AutoMapper setup (if needed)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Setup Minimal API
var app = builder.Build();

app.MapGet("/api/shopping", async (ICompraAppService compraAppService, IMapper mapper) =>
{
    var compras = await compraAppService.GetAllComprasAsync();
    var comprasDto = mapper.Map<List<CompraDto>>(compras);
    return Results.Json(comprasDto, new JsonSerializerOptions { PropertyNamingPolicy = null });
});

// Run the app
app.Run();
