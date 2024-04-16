using DesafioAPI.Repositories;
using DesafioAPI.Repositories.Interfaces;
using DesafioAPI.Services;
using DesafioAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ADD OWN DEPENDENCY INJECTIONS --------------------------------------
builder.Services.AddSingleton<IContextDB, ContextDB>();

builder.Services.AddSingleton<IProductService, ProductService>();
// ADD OWN DEPENDENCY INJECTIONS --------------------------------------

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
