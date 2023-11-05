namespace CodingChallenges.Library.Contracts;

public interface IFileSystem
{
    FileInfo ReadFile(string fileName);
    string ReadAllText(string path);
    long GetBytes(string filename);
    int GetNumberOfLines(string fileName);
}