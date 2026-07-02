using AppSetup.Models;
using Cards.Data;

namespace AppSetup.Commands;

internal class SeedData : ICommand
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICardsContext _cardsContext;
    private readonly TimeProvider _timeProvider;

    public SeedData(ApplicationDbContext dbContext, ICardsContext cardsContext, TimeProvider timeProvider)
    {
        _dbContext = dbContext;
        _cardsContext = cardsContext;
        _timeProvider = timeProvider;
    }

    public int Order => 2;

    public async Task<Maybe<bool>> Run()
    {
        if (_dbContext.Cards.Any())
        {
            return Result.Nothing();
        }

        var now = _timeProvider.GetUtcNow();

        var cardEntities = _cardsContext.CardCollection.Select(c => new CardEntity
        {
            Id = Guid.NewGuid(),
            DateCreated = now,
            DateModified = now,
            Card = c,
        }).ToList();

        try
        {
            await _dbContext.Cards.AddRangeAsync(cardEntities);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Erred(ex);
        }

        return Result.Success();
    }
}
