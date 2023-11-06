using CodingChallenges.Library.Contracts;

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
        catch
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
        catch
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
        catch
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
        catch
        {
            return 0;
        }
    }

    //

    private readonly IFileSystem decorated;
}