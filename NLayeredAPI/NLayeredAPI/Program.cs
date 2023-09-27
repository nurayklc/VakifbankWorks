using NLayeredAPI.Extension;
using Serilog;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

Log.Logger = new LoggerConfiguration().WriteTo.File("../logs/myapp.txt", rollingInterval: RollingInterval.Day).Enrich
    .FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Services.AddLogging();
builder.Logging.AddSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContextDI(builder.Configuration);
builder.Services.AddServicesDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParamApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
