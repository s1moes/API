var builder = WebApplication.CreateBuilder(args);

// Get the assigned PORT from Railway, default to 8080
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Add services to the container
builder.Services.AddControllers();
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

app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

// Add HealthCheck Middleware
app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
