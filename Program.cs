using ApiELection.Interfaces;
using ApiELection.models;
using ApiELection.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//lancer la connexion avec la base de donnees
builder.Services.AddDbContext<ApiContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connexion")));

//lier les services aux interfaces
builder.Services.AddTransient<InterfaceCentre,ServiceCentre>();
builder.Services.AddTransient<InterfaceBureau, ServiceBureau>();
builder.Services.AddTransient<InterfaceElecteur, ServiceElecteur>();

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
