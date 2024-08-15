using Hangfire;
using Microsoft.EntityFrameworkCore;
using Weather_Application_Backend.Data;
using Weather_Application_Backend.Jobs;
using Weather_Application_Backend.Mappers;
using Weather_Application_Backend.Repository.ForecastRepository;
using Weather_Application_Backend.Repository.MeasurementsRepository;
using Weather_Application_Backend.Service.CityService;
using Weather_Application_Backend.Service.ForecastService;
using Weather_Application_Backend.Service.MeasurementService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();
builder.Services.AddScoped<IForecastRepository, ForecastRepository>();

// Services
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();
builder.Services.AddScoped<IForecastService, ForecastService>();

//Mappers
builder.Services.AddScoped<IAPIDtoMapper, APIDtoMapper>();


builder.Services.AddDbContext<WeatherForecastContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:WeatherForecastDbConnectionString"]);
});

builder.Services.AddHangfire((sp, config) =>
{
    var connection_string = builder.Configuration["ConnectionStrings:WeatherForecastDbConnectionString"];
    config.UseSqlServerStorage(connection_string);
});

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<OpenWeatherMapApiJob>("Scraping-Air-Moepp-MK", x => x.scrapeData(), "*/50 * * * *");
RecurringJob.AddOrUpdate<PredictValuesJob>("Predict-Air-Moepp-MK", x => x.predictValues(), "*/59 * * * *");

app.Run();
