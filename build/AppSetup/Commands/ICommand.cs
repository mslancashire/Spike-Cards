using AppSetup.Models;

namespace AppSetup.Commands;

internal interface ICommand
{
    bool IsActive() => true;

    string Name => GetType().Name;

    int Order { get; }

    Task<Maybe<bool>> Run();
}
