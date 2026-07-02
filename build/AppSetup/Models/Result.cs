namespace AppSetup.Models;

internal static class Result
{
    internal static Maybe<bool> Success() => new Something<bool>(true);

    internal static Maybe<bool> Nothing() => new Nothing<bool>();

    internal static Maybe<bool> Erred(Exception ex) => new Erred<bool>(ex);
}
