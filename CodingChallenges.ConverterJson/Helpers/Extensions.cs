using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Helpers;

public static class Extensions
{
    public static Parser<TToken, T> InBraces<TToken, T, U, V>(this Parser<TToken, T> parser, Parser<TToken, U> before, Parser<TToken, V> after)
        => before
            .Then(parser)
            .Before(after);

    public static Parser<char, T> Bracketed<T>(this Parser<char, T> p) =>
        p.Between(LeftBracket, RightBracket);

    public static Parser<char, T> Curled<T>(this Parser<char, T> p) =>
        p.Between(LeftBrace, RightBrace);

    //

    private static readonly List<char> EscapeChars = new() {'\"', '\\', 'b', 'f', 'n', 'r', 't'};

    private static Parser<char, char> LeftBrace => Tok('{');
    private static Parser<char, char> RightBrace => Tok('}');

    private static Parser<char, char> LeftBracket => Tok('[');
    private static Parser<char, char> RightBracket => Tok(']');

    private static Parser<char, T> Tok<T>(Parser<char, T> parser)
        => parser.Before(SkipWhitespaces);

    private static Parser<char, char> Tok(char value)
        => Tok(Char(value));

    // private Parser<char, char> LeftBrace => Tok('{');
    // private Parser<char, char> RightBrace => Tok('}');
    // private Parser<char, char> LeftBracket => Tok('[');
    // private Parser<char, char> RightBracket => Tok(']');
    // private Parser<char, string> True => Tok("true");
    // private Parser<char, string> False => Tok("false");
}