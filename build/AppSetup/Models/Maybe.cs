namespace AppSetup.Models;

public abstract class Maybe<T>
{
}

public class Nothing<T> : Maybe<T>
{
}

public class Aborted<T> : Maybe<T>
{
}

public class Something<T> : Maybe<T>
{
    public T Value { get; }

    public Something(T value)
    {
        Value = value;
    }
}

public class Failed<T> : Maybe<T>
{
    public string Reason { get; }

    public Failed(string reason)
    {
        Reason = reason;
    }
}

public class Erred<T> : Maybe<T>
{
    public Exception Exception { get; }

    public Erred(Exception exception)
    {
        Exception = exception;
    }
}
