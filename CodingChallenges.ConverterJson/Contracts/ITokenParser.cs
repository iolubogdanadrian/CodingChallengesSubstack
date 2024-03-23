using CodingChallenges.ConverterJson.Models;
using Pidgin;

namespace CodingChallenges.ConverterJson.Contracts;

public interface ITokenParser
{
    Parser<char, BaseToken> GetToken();
}