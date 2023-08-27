using CustomerAPI.Models;
using CustomerAPI.Repositories.Classes;
using CustomerAPI.Repositories.Interfaces;
using CustomerAPI.Services.Classes;
using CustomerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration; // Get the configuration

string connectionString = configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerTypeServices, CustomerTypeServices>();
builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CustomerAPIDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
