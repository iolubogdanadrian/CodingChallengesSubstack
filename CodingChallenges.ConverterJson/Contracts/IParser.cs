using CodingChallenges.ConverterJson.Models;
using Pidgin;

namespace CodingChallenges.ConverterJson.Contracts;

public interface IParser
{
    Parser<char, BaseToken> JsonInternal();
}