using Cards.API.Common.Health;
using Cards.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// api boiler plate
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthAndLiveChecks();

// services
builder.Services.AddScoped<ICardsRepository, CardsRepository>();
builder.Services.AddScoped<ICardsContext, GreekCardsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthAndLiveChecks();

// basic cards layer
app.MapGet("/api/cards/get-cards", GetAll);

// card search layer
app.MapGet("/api/cards/search/by-name/{name}", SearchByName);
app.MapGet("/api/cards/search/by-cost/{cost:int}", SearchByCost);
app.MapGet("/api/cards/search/by-health/{health:int}", SearchByHealth);
app.MapGet("/api/cards/search/by-attack/{attack:int}", SearchByAttack);
app.MapGet("/api/cards/search/by-description/{description}", SearchByDescription);

app.Run();


static async Task<IResult> GetAll(ICardsRepository repository)
    => TypedResults.Ok(await repository.GetCardCollection());

static async Task<IResult> SearchByName(string name, ICardsRepository repository)
    => TypedResults.Ok(await repository.FindCardsByName(name));

static async Task<IResult> SearchByCost(int cost, ICardsRepository repository)
    => TypedResults.Ok(await repository.FindCardsByCost(cost));

static async Task<IResult> SearchByHealth(int health, ICardsRepository repository)
    => TypedResults.Ok(await repository.FindCardsByHealth(health));

static async Task<IResult> SearchByAttack(int attack, ICardsRepository repository)
    => TypedResults.Ok(await repository.FindCardsByAttack(attack));

static async Task<IResult> SearchByDescription(string description, ICardsRepository repository)
    => TypedResults.Ok(await repository.FindCardsByDescription(description));