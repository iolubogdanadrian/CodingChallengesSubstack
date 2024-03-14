using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class StringParser : ITokenParser
{
    public Parser<char, Json> GetToken() => StringToken()
        .Select<Json>(s => new JsonString(s))
        .Labelled("JsonStringType");

    //

    private Parser<char, string> StringToken() => Token(c => c != '"')
        .ManyString()
        .Between(Quote);

    private static Parser<char, char> Quote => Tok('"');

    private static Parser<char, char> Tok(char value)
        => Tok(Char(value));

    private static Parser<char, T> Tok<T>(Parser<char, T> parser)
        => parser.Before(SkipWhitespaces);
}