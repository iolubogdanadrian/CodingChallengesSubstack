using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

// ReSharper disable StaticMemberInitializerReferesToMemberBelow
#pragma warning disable CS8604 // Possible null reference argument.
namespace CodingChallenges.ConverterJson.Services;

public class JsonParser
{
    public Result<char, Json> Parse(string input) => JsonInternal()
        .Parse(input);

    //

    private Parser<char, Json> JsonInternal() =>
        JsonStringType().Or(Rec(JsonBoolType)).Or(Rec(JsonObjectType));

    private Parser<char, Json> JsonStringType() =>
        StringToken()
            .Select<Json>(s => new JsonString(s))
            .Labelled("JsonStringType");

    private Parser<char, Json> JsonBoolType() => BoolToken()
        .Select(it => (Json) new JsonBool(it))
        .Labelled("JsonBoolType");

    private Parser<char, Json> JsonObjectType() =>
        MembersTokens()
            .Between(SkipWhitespaces)
            .Separated(Comma)
            .Between(LeftBrace, RightBrace)
            .Select<Json>(
                kvps =>
                {
                    var fifoDictionary = new FifoDictionary<string, Json>();
                    foreach (var item in kvps)
                        fifoDictionary.Add(item.Key, item.Value);
                    return new JsonObject(fifoDictionary);
                })
            .Labelled("JsonObjectType");

    //

    private Parser<char, string> StringToken() =>
        Token(c => c != '"')
            .ManyString()
            .Between(Quote);

    private static Parser<char, bool> BoolToken()
    {
        var @true = Literal("true", true);
        var @false = Literal("false", false);
        return OneOf(@true, @false);
    }

    private static Parser<char, bool> Literal(string literal, bool value)
        => Map(_ => value, String(literal));

    private Parser<char, KeyValuePair<string, Json>> MembersTokens() => StringToken()
        .Before(ColonWhitespace())
        .Then(JsonInternal(), (name, value) => new KeyValuePair<string, Json>(name, value));

    //

    private static readonly List<char> EscapeChars = new() {'\"', '\\', 'b', 'f', 'n', 'r', 't'};

    private Parser<char, char> Comma => Tok(',');
    private Parser<char, char> LeftBrace => Tok('{');
    private Parser<char, char> RightBrace => Tok('}');
    private Parser<char, char> LeftBracket => Tok('[');
    private Parser<char, char> RightBracket => Tok(']');
    private Parser<char, char> Quote => Tok('"');
    private Parser<char, char> Colon => Tok(':');
    private Parser<char, string> True => Tok("true");
    private Parser<char, string> False => Tok("false");

    private Parser<char, char> ColonWhitespace() => Colon
        .Between(SkipWhitespaces);

    private static Parser<char, T> Tok<T>(Parser<char, T> parser)
        => parser.Before(SkipWhitespaces);

    private static Parser<char, char> Tok(char value)
        => Tok(Char(value));

    private static Parser<char, string> Tok(string value)
        => Tok(String(value));
}