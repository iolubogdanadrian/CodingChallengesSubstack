using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Services;

public class JsonParser(IEnumerable<ITokenParser> parsers)
{
    public Result<char, BaseToken> Parse(string input) => JsonWrapper()
        .Parse(input);

    //

    private Parser<char, BaseToken> JsonWrapper() => parsers
        .Select(parser => Rec(parser.GetToken))
        .Aggregate((acc, parser) => acc.Or(parser));
}