using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Helpers;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class ObjectParser() : ITokenParser
{
    public IParser Parsers { get; set; }

    public Parser<char, Json> GetToken() => MembersTokens()
        .Between(SkipWhitespaces)
        .Separated(Comma)
        .Curled()
        .Select(CreateJsonObject)
        .Labelled("JsonObjectType");

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

    private static Json CreateJsonObject(IEnumerable<KeyValuePair<string, Json>> kvps)
    {
        var fifoDictionary = new FifoDictionary<string, Json>();
        foreach (var item in kvps)
            fifoDictionary.Add(item.Key, item.Value);
        return new JsonObject(fifoDictionary);
    }

    private Parser<char, KeyValuePair<string, Json>> MembersTokens() => StringToken()
        .Before(ColonWhitespace())
        .Then(Parsers.JsonInternal(), (name, value) => new KeyValuePair<string, Json>(name, value));

    private Parser<char, char> ColonWhitespace() => Colon
        .Between(SkipWhitespaces);

    private Parser<char, string> StringToken() => Token(c => c != '"')
        .ManyString()
        .Between(Quote);
}