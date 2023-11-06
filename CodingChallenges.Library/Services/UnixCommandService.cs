using CodingChallenges.Library.Contracts;
using CodingChallenges.Library.Models;

namespace CodingChallenges.Library.Services;

public class UnixCommandService : IUnixCommandService
{
    public UnixCommandService(IFileSystem fs)
    {
        this.fs = fs;
    }

    public string Apply(Command command)
    {
        command.VerifyCommand();

        return command.Option switch
        {
            Constants.OPTION_NUMBER_OF_BYTES => HandleNumberOfBytes(),
            Constants.OPTION_NUMBER_OF_LINES => HandleNumberOfLines(),
            Constants.OPTION_NUMBER_OF_WORDS => HandleNumberOfWords(),
            Constants.OPTION_NUMBER_OF_CHARACTERS => HandleNumberOfCharacters(),
            _ => "",
        };

        string HandleNumberOfBytes()
        {
            var bytesFromFile = fs.GetBytes(command.FileName);
            return $"{bytesFromFile} {command.FileName}";
        }

        string HandleNumberOfLines()
        {
            var numberOfLines = fs.GetNumberOfLines(command.FileName);
            return $"{numberOfLines} {command.FileName}";
        }

        string HandleNumberOfWords()
        {
            var words = fs.ReadAllText(command.FileName).Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            return $"{words.Length} {command.FileName}";
        }

        string HandleNumberOfCharacters()
        {
            var characters = fs.ReadAllText(command.FileName).Length;
            return $"{characters} {command.FileName}";
        }
    }

    //

    private readonly IFileSystem fs;
}