using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class BoolParser : ITokenParser
{
    public IParser Parsers { get; set; }

    public Parser<char, Json> GetToken() => BoolToken()
        .Select(it => (Json) new JsonBool(it))
        .Labelled("JsonBoolType");

    public Parser<char, bool> BoolToken()
    {
        var @true = LiteralBool("true", true);
        var @false = LiteralBool("false", false);
        return OneOf(@true, @false);
    }

    private static Parser<char, bool> LiteralBool(string literal, bool value)
        => Map(_ => value, String(literal));
}