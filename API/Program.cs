using API.Models;
using API.Services;
using AutoMapper;
using MongoDB.Driver;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<ICompraAppService, CompraAppService>();

// MongoDB setup
var connectionString = "mongodb+srv://s1moes:Futebolista23.@todo.kdhkh.mongodb.net/?retryWrites=true&w=majority&appName=ToDo";
var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase("ToDo");
builder.Services.AddSingleton<IMongoDatabase>(database);
builder.Services.AddSingleton<IMongoClient>(mongoClient);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();

// AutoMapper setup (if needed)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Setup Minimal API
var app = builder.Build();

// Define the endpoints
app.MapGet("/api/compras", async (ICompraAppService compraAppService, IMapper mapper) =>
{
    var compras = await compraAppService.GetAllComprasAsync();
    var comprasDto = mapper.Map<List<CompraDto>>(compras);
    return Results.Ok(JsonConvert.SerializeObject(comprasDto));
});

// Run the app
app.Run();
