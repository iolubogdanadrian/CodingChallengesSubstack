namespace CodingChallenges.Library.Models;

public record Command(string Text)
{
    // public FileInfo? File { get; set; }

    public string[] Parts => Text.Split(' ');
    public string Syntax => Parts[0];
    public string Option => Parts[1];
    public string FileName => Parts[2];

    public void VerifyCommand()
    {
        if (Parts.Length < 3)
            throw new Exception("Invalid command");

        if (Syntax != Constants.COMMAND_SYNTAX)
            throw new Exception("Invalid command syntax");
    }
}