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

    private Parser<char, string> StringToken()
    {
        var escapeChar = Char('\\')
            .Then(
                _ =>
                    OneOf(
                        Char('"').Select(_ => '"'),
                        Char('\\').Select(_ => '\\'),
                        Char('/').Select(_ => '/'),
                        Char('b').Select(_ => '\b'),
                        Char('f').Select(_ => '\f'),
                        Char('n').Select(_ => '\n'),
                        Char('r').Select(_ => '\r'),
                        Char('t').Select(_ => '\t'),
                        UnicodeEscape
                    )
            );

        var stringChar = escapeChar.Or(AnyCharExcept('"', '\\'));

        return stringChar
            .ManyString()
            .Between(Quote)
            .Select(chars => new string(chars));
    }

    private static readonly Parser<char, char> UnicodeEscape = Char('u')
        .Then(_ => HexDigit.Repeat(4))
        .Select(hexDigits => (char) Convert.ToInt32(new string((char[]?) hexDigits), 16));

    private static readonly Parser<char, char> HexDigit = Digit.Or(OneOf('A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f'));

    private static readonly Parser<char, char> Quote = Char('"');
}