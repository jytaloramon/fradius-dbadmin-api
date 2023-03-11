using RadiusDomain.User.Entities;
using RadiusDomain.User.Presentation;
using RadiusDomain.User.Presentation.Interfaces;
using RadiusDomain.User.Repositories;
using RadiusDomain.User.Repositories.Interfaces;
using RadiusDomain.User.UseCases;
using RadiusDomain.User.UseCases.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IRadiusUserAttributeRepository>(new RadiusUserAttributeRepository(new[]
{
    new RadiusUserAttribute("SHA1", "Password"),
    new RadiusUserAttribute("SHA2", "Password"),
    new RadiusUserAttribute("IP", "Network"),
}));

builder.Services.AddTransient<IRadiusUserAttributePresentation, RadiusUserAttributePresentation>();
builder.Services.AddTransient<IRadiusUserAttributeUseCases, RadiusUserAttributeUseCases>();

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