namespace CodingChallenges.Monads.Services;

public abstract class Maybe<T>
{
    public abstract Maybe<U> Bind<U>(Func<T, Maybe<U>> func);
    public static Maybe<T> Just(T value) => new Just<T>(value);
    public static Maybe<T> Nothing() => new Nothing<T>();
}

public class Just<T> : Maybe<T>
{
    private readonly T _value;

    public Just(T value)
    {
        _value = value;
    }

    public override Maybe<U> Bind<U>(Func<T, Maybe<U>> func) => func(_value);
}

public class Nothing<T> : Maybe<T>
{
    public override Maybe<U> Bind<U>(Func<T, Maybe<U>> func) => new Nothing<U>();
}