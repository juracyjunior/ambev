using Ambev.DeveloperEvaluation.AppService;
using Ambev.DeveloperEvaluation.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(
    builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(OrderAppService).Assembly);

var app = builder.Build();

// Ensure Serilog is flushed on application shutdown
app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
