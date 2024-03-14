using System.Globalization;
using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class NumericParser : ITokenParser
{
    public Parser<char, Json> GetToken() => NumericToken()
        .Select(it => (Json) new JsonNumeric(it))
        .Labelled("JsonNumericType");

    //

    private static Parser<char, string> DecimalBeforeString() =>
        Token(c => char.IsDigit(c) || c == '-' || c == '+' || c == '.' || c == 'e' || c == 'E')
            .AtLeastOnce()
            .Select(chars => new string(chars.ToArray()));

    private Parser<char, double> NumericToken() => DecimalBeforeString()
        .Before(SkipWhitespaces)
        .Select(it => double.Parse(it, CultureInfo.InvariantCulture));
}