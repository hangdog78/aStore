using Microsoft.AspNetCore.Mvc.ApplicationModels;
using aStoreServer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers(cfg =>
{
    cfg.EnableEndpointRouting = false;
    cfg.Conventions.Add(new RouteTokenTransformerConvention(
      new SlugifyParameterTransformer()));
});

// Добавляем лог в файл
builder.Logging.ClearProviders();
var logpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", $"log-{DateTime.UtcNow:dd-MM-y--HH-mm-ss}.txt");
builder.Logging
    .AddSerilog(new LoggerConfiguration()
        .WriteTo.File(path: logpath, rollingInterval: RollingInterval.Day)
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
        .CreateLogger())
    .AddConsole();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();
app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();