using Microsoft.Extensions.Configuration;
using NewApi.Business;
using NewApi.Models.Common;
using NewApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddHttpClient<IFlightService, FlightService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IJourneySearchServices,JourneySearchServices>();
builder.Services.Configure<ExternalServicesOptions>(builder.Configuration.GetSection("ExternalServices"));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

