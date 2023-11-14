using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace CodingChallenges.ConverterJson.Services;

public static class PidginJsonParser
{
    private static Parser<char, object?> Literal(string literal, object? value)
        => Map(_ => value, String(literal));

    private static readonly Parser<char, string> String =
        Token(c => c != '"').ManyString().Between(Char('"'));

    private static readonly Parser<char, object?> Json =
        Rec(
            () =>
            {
                var @true = Literal("true", true);
                var @false = Literal("false", false);
                var @null = Literal("null", null);
                var @int = Map(digits => (object?) int.Parse(digits), Digit.AtLeastOnceString());

                return OneOf(@true, @false, @null, @int, String.Cast<object?>(), Array!, Object!);
            });

    private static readonly Parser<char, object?> Array =
        List('[', Json, ']', items => (object?) items.ToArray());

    private static Parser<char, object?> Object
    {
        get
        {
            var ColonWhitespace = Char(':').Between(SkipWhitespaces);

            var Pair =
                String
                    .Before(ColonWhitespace)
                    .Then(Json, (name, val) => new KeyValuePair<string, object?>(name, val));

            return List('{', Pair, '}', pairs => (object?) new Dictionary<string, object?>(pairs));
        }
    }

    private static Parser<char, TValue> List<TItem, TValue>(
        char open,
        Parser<char, TItem> item,
        char close,
        Func<IEnumerable<TItem>, TValue> convert) =>
        item.Between(SkipWhitespaces)
            .Separated(Char(','))
            .Between(Char(open), Char(close))
            .Select(convert);

    public static object? Parse(string input)
    {
        var result = Json.Parse(input);

        return result.Value;
    }
}