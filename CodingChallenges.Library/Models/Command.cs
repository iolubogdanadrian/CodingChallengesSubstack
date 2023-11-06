namespace CodingChallenges.Library.Models;

public record Command(string Text)
{
    public string[] Parts => Text.Split(' ');

    public string Syntax => Parts[0];
    public string Option => Parts.Length < 3 ? "" : Parts[1];
    public string FileName => Parts.Length < 3 ? Parts[1] : Parts[2];

    public void VerifyCommand()
    {
        if (Parts.Length < 2)
            throw new Exception("Invalid command");

        if (Syntax != Constants.COMMAND_SYNTAX)
            throw new Exception("Invalid command syntax");
    }
}