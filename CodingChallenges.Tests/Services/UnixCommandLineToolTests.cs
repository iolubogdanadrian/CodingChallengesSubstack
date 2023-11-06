using System.Globalization;
using CodingChallenges.Library.Contracts;
using CodingChallenges.Library.Models;
using CodingChallenges.Library.Services;
using CodingChallenges.Tests.Properties;
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
        var japaneseCulture = CultureInfo.GetCultureInfo("en-US");
        CultureInfo.CurrentCulture = japaneseCulture;
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

    [TestMethod("Get the number of words in a file")]
    public void Test03()
    {
        var command = new Command("ccwc -w test.txt");
        fs.Setup(it => it.ReadAllText("test.txt")).Returns(Resources.test);

        var result = sut.Apply(command);

        Assert.AreEqual("58164 test.txt", result);
    }

    [TestMethod("Get the number of characters in a file")]
    public void Test04()
    {
        var command = new Command("ccwc -m test.txt");
        fs.Setup(it => it.ReadAllText("test.txt")).Returns(Resources.test);

        var result = sut.Apply(command);

        Assert.AreEqual("339291 test.txt", result);
    }
}