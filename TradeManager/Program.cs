using Npgsql;
using System.Data;
using TradeManager.Repositories;
using TradeManager.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//*************************************

var dbConnectionString = builder.Configuration.GetValue<string>("MyConnectionString");
builder.Services.AddScoped<IDbConnection>((connection) => new NpgsqlConnection(dbConnectionString));
builder.Services.AddScoped<IOperationRepository, OperationRepository>();

//*************************************


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

app.Run();
