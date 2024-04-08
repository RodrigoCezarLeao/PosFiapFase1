using PosAluraFase1.Repository;

var builder = WebApplication.CreateBuilder(args);

// My Dependency injection
builder.Services.AddKeyedSingleton<IDbWorker, DbWorker>("banco_singleton");
builder.Services.AddKeyedScoped<IDbWorker, DbWorker>("banco_scoped");
builder.Services.AddKeyedTransient<IDbWorker, DbWorker>("banco_transient");

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
