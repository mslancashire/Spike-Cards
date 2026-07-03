using Cards.API.Common.Exceptions;
using Cards.API.Common.HealthChecks;
using Cards.Data;
using Cards.Data.Helpers;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// application settings, user secrets and environmental variables added by default.

var commonAssembly = Assembly.GetAssembly(typeof(Cards.API.Common.AssemblyReference)) ?? throw new ApplicationException("Common Assembly not found");

// add services to the container.
builder.Services.SetupDB(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddValidatorsFromAssembly(commonAssembly, includeInternalTypes: true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthAndLiveChecks();
builder.Services.SetupExceptionHandler();

// add data dependencies
builder.Services.AddScoped<ICardsRepository, CardsRepository>();
builder.Services.AddScoped<ICardsContext, GreekCardsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SetupExceptionHandling();

app.UseHttpsRedirection();

app.MapHealthAndLiveChecks();

app.UseAuthorization();

app.MapControllers();

app.Run();
