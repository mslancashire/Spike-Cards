using AppSetup.Models;
using Cards.Data;
using Microsoft.EntityFrameworkCore;

namespace AppSetup.Commands;

internal class RunMigrations : ICommand
{
    private readonly ApplicationDbContext _dbContext;

    public RunMigrations(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Order => 1;

    public async Task<Maybe<bool>> Run()
    {
        try
        {
            await _dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            return Result.Erred(ex);
        }

        return Result.Success();
    }
}
