using Cards.API.Common.Documentation;
using Cards.API.Common.DTO.Search;
using Cards.API.Common.HealthChecks;
using Cards.API.Common.Validation;
using Cards.Data;
using Cards.Data.Helpers;
using Cards.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// application settings, user secrets and environmental variables added by default.

// db
builder.Services.SetupDB(builder.Configuration);

// configuration
builder.Services.Configure<SearchValidationSettings>(
    builder.Configuration.GetSection("ValidationSettings"));

var commonAssembly = Assembly.GetAssembly(typeof(Cards.API.Common.AssemblyReference)) ?? throw new ApplicationException("Common Assembly not found");

// api boiler plate
builder.Services.AddValidatorsFromAssembly(commonAssembly, includeInternalTypes: true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{commonAssembly.GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);
});
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

app.MapHealthAndLiveChecks();

// basic cards layer
app.MapGet("/api/cards/get-cards", GetAll)
    .AllowAnonymous()
    .AddStandardData<IEnumerable<BasicCard>>(
        "Get All Cards",
        "Gets all Cards.",
        "Cards"
    );

// card search layer
app.MapGet("/api/cards/search/by-name/{Name}", SearchByName)
    .AllowAnonymous()
    .AddStandardData<IEnumerable<BasicCard>>(
        "Search Cards By Name",
        "Get all Cards with the same provided name (case-insensitive).",
        "Search"
    );

app.MapGet("/api/cards/search/by-cost/{Cost:int}", SearchByCost)
    .AllowAnonymous()
    .AddStandardData<IEnumerable<BasicCard>>(
        "Search Cards By Cost",
        "Get all Cards with provided cost value.",
        "Search"
    );

app.MapGet("/api/cards/search/by-health/{Health:int}", SearchByHealth)
    .AllowAnonymous()
    .AddStandardData<IEnumerable<BasicCard>>(
        "Search Cards By Health",
        "Get all Cards with provided health value.",
        "Search"
    );

app.MapGet("/api/cards/search/by-attack/{Attack:int}", SearchByAttack)
    .AllowAnonymous()
    .AddStandardData<IEnumerable<BasicCard>>(
        "Search Cards By Attach",
        "Get all Cards with provided attack value.",
        "Search"
    );

app.MapGet("/api/cards/search/by-description/{Description}", SearchByDescription)
    .AllowAnonymous()
    .AddStandardData<IEnumerable<BasicCard>>(
        "Search Cards By Description",
        "Get all Cards those description contains the provided statement (case-insensitive).",
        "Search"
    );

app.Run();


static async Task<IResult> GetAll(ICardsRepository repository)
    => TypedResults.Ok(await repository.GetCardCollection());

static async Task<IResult> SearchByName([AsParameters] SearchByName request, [FromServices] IValidator<SearchByName> validator, ICardsRepository repository)
    => await HandleSearch(request, r => r.FindCardsByName(request.Name), validator, repository);

static async Task<IResult> SearchByCost([AsParameters] SearchByCost request, [FromServices] IValidator<SearchByCost> validator, ICardsRepository repository)
    => await HandleSearch(request, r => r.FindCardsByCost(request.Cost), validator, repository);

static async Task<IResult> SearchByHealth([AsParameters] SearchByHealth request, [FromServices] IValidator<SearchByHealth> validator, ICardsRepository repository)
    => await HandleSearch(request, r => r.FindCardsByHealth(request.Health), validator, repository);

static async Task<IResult> SearchByAttack([AsParameters] SearchByAttack request, [FromServices] IValidator<SearchByAttack> validator, ICardsRepository repository)
    => await HandleSearch(request, r => r.FindCardsByAttack(request.Attack), validator, repository);

static async Task<IResult> SearchByDescription([AsParameters] SearchByDescription request, [FromServices] IValidator<SearchByDescription>? validator, ICardsRepository repository)
    => await HandleSearch(request, r => r.FindCardsByDescription(request.Description), validator, repository);

static async Task<IResult> HandleSearch<TSearchType>(
    TSearchType request,
    Func<ICardsRepository, Task<IEnumerable<BasicCard>>> searchAction,
    IValidator<TSearchType>? validator,
    ICardsRepository repository)
{
    var validationResult = validator?.Validate(request);
    if (validationResult?.IsValid == false)
    {
        return TypedResults.BadRequest(validationResult.ToProblemDetails(nameof(SearchByName)));
    }

    return TypedResults.Ok(await searchAction(repository));
}

/* # Parameter Binding
 * 
 * Instead of using [AsParameter] can also to Custom Binding.
 * ASP Core will scan for matches on ValueTask<T?> BindAsync(HttpContext context).
 * You can bind up the object as you need.
 */

/* # Fluent Validation
 * 
 * For auto validation, could use https://github.com/SharpGrip/FluentValidation.AutoValidation.
 * This can work for MVC and minimal APIs.
 * You can also configure a custom Result and set as the Default.
 */