using System.Collections.Immutable;
using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Helpers;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class ArrayParser() : ITokenParser
{
    public IParser Parsers { get; set; }

    public Parser<char, Json> GetToken() => Parsers.JsonInternal()
        .Between(SkipWhitespaces)
        .Separated(Comma)
        .Bracketed()
        .Select(CreateJsonArray)
        .Labelled("JsonArrayType");

    //

    private static Parser<char, char> Comma => Tok(',');
    private static Parser<char, char> Quote => Tok('"');
    private static Parser<char, char> Colon => Tok(':');

    private static Parser<char, T> Tok<T>(Parser<char, T> parser)
        => parser.Before(SkipWhitespaces);

    private static Parser<char, char> Tok(char value)
        => Tok(Char(value));

    private static Parser<char, string> Tok(string value)
        => Tok(String(value));

    private static Json CreateJsonArray(IEnumerable<Json> it) =>
        new JsonArray(it.ToImmutableArray());
}