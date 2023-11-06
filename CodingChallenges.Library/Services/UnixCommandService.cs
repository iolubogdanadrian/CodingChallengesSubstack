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

        var data = command.Option switch
        {
            Constants.OPTION_NUMBER_OF_BYTES => HandleNumberOfBytes(),
            Constants.OPTION_NUMBER_OF_LINES => HandleNumberOfLines(),
            Constants.OPTION_NUMBER_OF_WORDS => HandleNumberOfWords(),
            Constants.OPTION_NUMBER_OF_CHARACTERS => HandleNumberOfCharacters(),
            "" => HandleNoOptionIsProvided(),
            _ => "",
        };

        return $"{data} {command.FileName}";

        string HandleNumberOfBytes()
        {
            var bytesFromFile = fs.GetBytes(command.FileName);
            return bytesFromFile + "";
        }

        string HandleNumberOfLines()
        {
            var numberOfLines = fs.GetNumberOfLines(command.FileName);
            return numberOfLines + "";
        }

        string HandleNumberOfWords()
        {
            var words = fs.ReadAllText(command.FileName).Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            return words.Length + "";
        }

        string HandleNumberOfCharacters()
        {
            var characters = fs.ReadAllText(command.FileName).Length;
            return characters + "";
        }

        string HandleNoOptionIsProvided()
        {
            var numberOfBytes = HandleNumberOfBytes();
            var numberOfLines = HandleNumberOfLines();
            var numberOfWords = HandleNumberOfWords();
            return $"{numberOfLines}   {numberOfWords}  {numberOfBytes}";
        }
    }

    //

    private readonly IFileSystem fs;
}