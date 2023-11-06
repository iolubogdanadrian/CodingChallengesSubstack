using CodingChallenges.Library.Contracts;

#pragma warning disable CS0168 // Variable is declared but never used

namespace CodingChallenges.Library.Services;

public class SafeFileSystemDecorator : IFileSystem
{
    public SafeFileSystemDecorator(IFileSystem decorated)
    {
        this.decorated = decorated;
    }

    public FileInfo ReadFile(string fileName)
    {
        try
        {
            return decorated.ReadFile(fileName);
        }
        catch (Exception ex)
        {
            return new FileInfo(fileName);
        }
    }

    public string ReadAllText(string path)
    {
        try
        {
            return decorated.ReadAllText(path);
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public long GetBytes(string filename)
    {
        try
        {
            return decorated.GetBytes(filename);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public int GetNumberOfLines(string fileName)
    {
        try
        {
            return decorated.GetNumberOfLines(fileName);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    //

    private readonly IFileSystem decorated;
}