#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace CodingChallenges.Monads.Services;

public class Result<T>
{
    public static Result<T> Success(T result) => new(result, null);

    public static Result<T?> Failure(string error) => new(default(T), error);

    public bool IsSuccess => error == null;
    public bool IsFailure => error != null;

    public T Value
    {
        get
        {
            if (IsFailure)
                throw new InvalidOperationException("Cannot access value of a failed result.");

            return value;
        }
    }

    public string? Error
    {
        get
        {
            if (IsSuccess)
                throw new InvalidOperationException("Cannot access error of a successful result.");

            return error;
        }
    }

    public Result(string errorMessage)
    {
        error = errorMessage;
    }

    public Result<TR> Bind<TR>(Func<T, Result<TR>> f) => IsSuccess
        ? f(Value)
        : new Result<TR>(default(TR), error);

    public Result<T> Bind<TInput>(Result<TInput> result, Func<TInput, Result<T>> func) => result.IsSuccess
        ? func(result.Value)
        : Failure(result.Error)!;

    //

    private readonly T value;
    private readonly string? error;

    private Result(T value, string? error)
    {
        this.value = value;
        this.error = error;
    }
}