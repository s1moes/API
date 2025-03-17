using MongoDB.Driver;

var builder = WebApplication.CreateSlimBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

var connectionString = Environment.GetEnvironmentVariable("DbConnection");
var mongoClient = new MongoClient(connectionString);
var dataBaseName = "ToDo";
var dataBase = mongoClient.GetDatabase(dataBaseName);

builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton<IMongoDatabase>(dataBase);

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHealthChecks("/health");
app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
