using CodingChallenges.ConverterJson.Models;
using Pidgin;

namespace CodingChallenges.ConverterJson.Contracts;

public interface ITokenParser
{
    IParser Parsers { get; set; }

    Parser<char, Json> GetToken();
}