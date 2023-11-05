namespace CodingChallenges.Library.Contracts;

public interface IFileSystem
{
    FileInfo ReadFile(string fileName);
    long GetBytes(string filename);
    int GetNumberOfLines(string fileName);
}