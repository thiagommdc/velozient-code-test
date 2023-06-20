using drone_delivery_service_api;
using drone_delivery_service_api.Business;
using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context;
using drone_delivery_service_api.Context.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

string _customPolicyCors = "CustomPolicyCors";

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IDroneBusiness, DroneBusiness>();
builder.Services.AddSingleton<IDroneContext, DroneContext>();
builder.Services.AddSingleton<IDeliveryBusiness, DeliveryBusiness>();
builder.Services.AddSingleton<IDeliveryContext, DeliveryContext>();
builder.Services.AddSingleton<IRoutesBusiness, RoutesBusiness>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(_customPolicyCors, builder =>
    {
        builder
            .SetIsOriginAllowed(x => _ = true)
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(_customPolicyCors);
app.UseAuthorization();

app.MapControllers();

app.Run();

