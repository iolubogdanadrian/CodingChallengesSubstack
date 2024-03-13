using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class NullParser : ITokenParser
{
    public IParser Parsers { get; set; }

    public Parser<char, Json> GetToken() => NullToken()
        .Select(_ => (Json) new JsonNull())
        .Labelled("JsonNullType");


    //

    private static Parser<char, object?> NullToken()
    {
        var nullType = LiteralObject("null", null);
        return OneOf(nullType);
    }

    private static Parser<char, object?> LiteralObject(string literal, object? value)
        => Map(_ => value, String(literal));
}