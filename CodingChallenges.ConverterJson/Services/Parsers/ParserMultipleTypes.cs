using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Models;
using Pidgin;
using static Pidgin.Parser;

namespace CodingChallenges.ConverterJson.Services.Parsers;

public class ParserMultipleTypes(IEnumerable<ITokenParser> parsers) : IParser
{
    public Parser<char, BaseToken> JsonInternal() => parsers
        .Select(parser => Rec(parser.GetToken))
        .Aggregate((acc, parser) => acc.Or(parser));
}