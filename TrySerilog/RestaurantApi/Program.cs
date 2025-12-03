using Microsoft.OpenApi;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .WriteTo.Console(
        theme: AnsiConsoleTheme.Code,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Restaurant API",
        Version = "v1",
        Description = "API for Simple Restaurant"
    });
    config.EnableAnnotations();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSingleton<IRestaurantInfoState, RestaurantInfoState>();
builder.Services.AddSingleton<IMainServiceRestaurant, MainServiceRestaurantImplementation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(config => // file server
    {
        config.RouteTemplate = "restaurant/api-docs/{documentName}/restaurant-api.json";
    });

    app.UseSwaggerUI(config => // UI
    {
        config.SwaggerEndpoint("/restaurant/api-docs/v1/restaurant-api.json", "Restaurant API v1");
        config.RoutePrefix = "restaurant/api-docs";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
