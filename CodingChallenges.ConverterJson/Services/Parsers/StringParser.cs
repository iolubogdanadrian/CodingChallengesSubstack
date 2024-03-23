using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Services.Parsers;

/*
    A string is a sequence of zero or more Unicode characters, wrapped in double quotes, using backslash escapes.
 */
public class StringParser : ITokenParser
{
    public Parser<char, BaseToken> GetToken() => StringToken()
        .Select<BaseToken>(s => new StringToken(s))
        .Labelled("JsonStringType");

    //

    public Parser<char, string> StringToken()
    {
        var stringToken = AnyCharExcept('"', '\\').ManyString().Between(Quote);
        return stringToken;
    }

    private static readonly Parser<char, char> Quote = Char('"');
}