var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();
