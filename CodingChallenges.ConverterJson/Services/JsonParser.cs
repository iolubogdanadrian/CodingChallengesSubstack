using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser<char>;
using static Pidgin.Parser;

// ReSharper disable StaticMemberInitializerReferesToMemberBelow
#pragma warning disable CS8604 // Possible null reference argument.
namespace CodingChallenges.ConverterJson.Services;

public class JsonParser
{
    public Result<char, Json> Parse(string input) =>
        Json().Parse(input);

    //

    private Parser<char, Json> Json() =>
        JsonParserLeftBracket().Or(Rec(JsonParserLeftBracket));

    private Parser<char, Json> JsonParserLeftBracket() => StructureJson()
        .Select(Transform);

    private Json Transform(string it) => new JsonString(it);

    private Parser<char, string> StructureJson()
    {
        var firstBracket = Token(c => c == '{').ManyString();
        var lastBracket = Token(c => c == '}').ManyString();

        return firstBracket.Or(lastBracket);
    }

    //

    private static readonly List<char> EscapeChars = new() {'\"', '\\', 'b', 'f', 'n', 'r', 't'};

    private Parser<char, char> LeftBrace => Char('{');
    private Parser<char, char> RightBrace => Char('}');
    private Parser<char, char> LeftBracket => Char('[');
    private Parser<char, char> RightBracket => Char(']');
    private Parser<char, char> Quote => Char('"');
    private Parser<char, char> Colon() => Char(':');

    private Parser<char, char> ColonWhitespace => Colon()
        .Between(SkipWhitespaces);

    private Parser<char, char> Comma => Char(',');

    private static Parser<char, T> Tok<T>(Parser<char, T> parser)
        => parser.Before(SkipWhitespaces);

    private static Parser<char, char> Tok(char value)
        => Tok(Char(value));

    private static Parser<char, string> Tok(string value)
        => Tok(String(value));
}