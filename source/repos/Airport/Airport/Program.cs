using Airport.Data;
using Airport.Data.Repositories;
using Airport.Logic;
using Airport.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AirportDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddTransient<IAirportRepository, AirportRepository>();
builder.Services.AddTransient<IDataService, DataService>();
builder.Services.AddTransient<ILogicService, LogicService>();
builder.Services.AddTransient<ISimulatorService, SimulatorService>();
builder.Services.AddTransient<Manager>();
builder.Services.AddTransient<Simulator>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()));

builder.Services.AddCors(options => options.AddPolicy("ReactPolicy", builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("ReactPolicy");

app.Run();
