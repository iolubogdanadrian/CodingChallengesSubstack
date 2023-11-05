using CodingChallenges.Library.Contracts;

namespace CodingChallenges.Library.Services;

public class FileSystem : IFileSystem
{
    public FileInfo ReadFile(string fileName) =>
        new(fileName);

    public long GetBytes(string filename) =>
        new FileInfo(filename).Length;

    public int GetNumberOfLines(string fileName) =>
        File.ReadLines(fileName).Count();
}