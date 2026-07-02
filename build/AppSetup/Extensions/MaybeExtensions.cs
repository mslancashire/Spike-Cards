using AppSetup.Models;

namespace AppSetup.Extensions;

public static class MaybeExtensions
{
    public static bool Success(this Maybe<bool> item)
        => item.TryGetValue(out var success) && success;

    public static bool Failed(this Maybe<bool> item)
        => item.Success() == false;

    public static bool IsNonResult<T>(this Maybe<T> item)
        => item is null || item is not Something<T>;

    public static bool IsSomething<T>(this Maybe<T> item)
        => item is not null && item is Something<T>;

    public static T GetValueOrDefault<T>(this Maybe<T> item, T defaultValue = default)
        => item is Something<T> something ? something.Value : defaultValue;

    public static bool TryGetValue<T>(this Maybe<T> item, out T value)
    {
        if (item is Something<T> something)
        {
            value = something.Value;
            return true;
        }

        value = default;
        return false;
    }

    public static Maybe<TOutput> ToNonResult<TInput, TOutput>(this Maybe<TInput> sourceResult)
    {
        if (sourceResult is null)
        {
            return new Nothing<TOutput>();
        }

        return sourceResult switch
        {
            Nothing<TInput> _ => new Nothing<TOutput>(),
            Aborted<TInput> _ => new Aborted<TOutput>(),
            Failed<TInput> failed => new Failed<TOutput>(failed.Reason),
            Erred<TInput> erred => new Erred<TOutput>(erred.Exception),
            _ => throw new Exception($"Conversion from {sourceResult.GetType().Name} to {typeof(TOutput).Name} not supported."),
        };
    }
}
