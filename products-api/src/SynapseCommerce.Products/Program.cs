using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SynapseCommerce.Shared;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from config
var connectionString = builder.Configuration.GetConnectionString("ProductsDbConnectionString");
// Get the password for the db conn string
var dbPassword = builder.Configuration["DbConnectionPassword"];
// Build the PosgreSQL conn string and insert the password
var npgsqlBuilder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString)
{
    Password = dbPassword
};
// Add the DbContext with the db conn string
builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseNpgsql(npgsqlBuilder.ConnectionString));

builder.Services.AddDiscoveredEndpoints();

var app = builder.Build();

app.MapDiscoveredEndpoints();

app.Run();
