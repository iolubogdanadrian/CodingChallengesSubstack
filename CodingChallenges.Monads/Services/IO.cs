namespace CodingChallenges.Monads.Services;

public class IO<T>
{
    private readonly Func<T> effect;

    public IO(Func<T> effect)
    {
        this.effect = effect;
    }

    public T UnsafePerformIO() => effect();

    public IO<U> Bind<U>(Func<T, IO<U>> func)
    {
        return new IO<U>(
            () =>
            {
                var result = UnsafePerformIO();
                return func(result).UnsafePerformIO();
            });
    }

    public static IO<T> Of(T value)
    {
        return new IO<T>(() => value);
    }

    public static IO<T> Of(Func<T> effect) => new(effect);
}