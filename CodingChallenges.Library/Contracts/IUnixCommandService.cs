using CodingChallenges.Library.Models;

namespace CodingChallenges.Library.Contracts;

public interface IUnixCommandService
{
    string Apply(Command command);
}