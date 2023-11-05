using CodingChallenges.Library.Contracts;
using CodingChallenges.Library.Models;

namespace CodingChallenges.Library.Services;

public class UnixCommandService
{
    public UnixCommandService(IFileSystem fs)
    {
        this.fs = fs;
    }

    public string Apply(Command command)
    {
        command.VerifyCommand();

        if (command.Option == Constants.OPTION_NUMBER_OF_BYTES)
        {
            var bytesFromFile = fs.GetBytes(command.FileName);
            return $"{bytesFromFile} {command.FileName}";
        }

        if (command.Option == Constants.OPTION_NUMBER_OF_LINES)
        {
            var numberOfLines = fs.GetNumberOfLines(command.FileName);
            return $"{numberOfLines} {command.FileName}";
        }

        if (command.Option == Constants.OPTION_NUMBER_OF_WORDS)
        {
            var words = fs.ReadAllText(command.FileName).Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            return $"{words.Length} {command.FileName}";
        }

        return "";
    }

    //

    private readonly IFileSystem fs;
}