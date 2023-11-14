#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace CodingChallenges.Monads.Services;

public class Option<T>
{
    private readonly T value;

    private Option(T value)
    {
        this.value = value;
        HasValue = true;
    }

    private Option()
    {
        HasValue = false;
    }

    public static Option<T> Some(T value) => new(value);

    public static Option<T> None() => new();

    public bool HasValue { get; }

    public T Value
    {
        get
        {
            if (!HasValue)
                throw new InvalidOperationException("Option has no value");
            return value;
        }
    }

    public Option<T> Do(Action<T> whenPresent, Action whenMissing)
    {
        if (HasValue)
            whenPresent(Value);
        else
            whenMissing();
        return this;
    }

    public Option<T> Do(Action<T> whenPresent) =>
        Do(whenPresent, () => { });

    public TR Match<TR>(Func<T, TR> whenPresent, Func<TR> whenMissing) =>
        HasValue ? whenPresent(Value) : whenMissing();

    public void Match(Action<T> some, Action none)
    {
        if (HasValue)
            some(Value);
        else
            none();
    }

    public Option<T> Match3(Func<T, Option<T>> some, Func<Option<T>> none) =>
        HasValue ? some(Value) : none();

    public Option<TR> Bind<TR>(Func<T, Option<TR>> f) =>
        HasValue ? f(Value) : Option<TR>.None();
}