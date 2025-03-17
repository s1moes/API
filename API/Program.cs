using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


var app = builder.Build();


app.UseHealthChecks("/health");
app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.Run();
