using CodingChallenges.Library.Contracts;
using CodingChallenges.Library.Models;
using CodingChallenges.Library.Services;
using Moq;

namespace CodingChallenges.Tests.Services;

[TestClass]
public class UnixCommandLineToolTests
{
    private readonly Mock<IFileSystem> fs = new();

    private readonly UnixCommandService sut;

    // ReSharper disable once ConvertConstructorToMemberInitializers
    public UnixCommandLineToolTests()
    {
        sut = new UnixCommandService(fs.Object);
    }

    [TestMethod("Get the number of bytes in a file")]
    public void Test01()
    {
        var command = new Command("ccwc -c test.txt");
        fs.Setup(it => it.GetBytes("test.txt")).Returns(342190);

        var result = sut.Apply(command);

        Assert.AreEqual("342190 test.txt", result);
    }

    [TestMethod("Get the number of lines in a file")]
    public void Test02()
    {
        var command = new Command("ccwc -l test.txt");
        fs.Setup(it => it.GetNumberOfLines("test.txt")).Returns(7145);

        var result = sut.Apply(command);

        Assert.AreEqual("7145 test.txt", result);
    }
}