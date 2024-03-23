using CodingChallenges.ConverterJson.Services.Parsers;
using Pidgin;

namespace CodingChallenges.Tests.Services;

[TestClass]
public class StringTokenTests
{
    private readonly StringParser sut = new();

    [TestMethod("Parse space")]
    public void Test1()
    {
        const string json = "\" \"";

        var result = sut.GetToken().Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("\" \"", result.Value.Show());
    }

    [TestMethod("Parse quote")]
    public void Test2()
    {
        const string INPUT = "\"\"\"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse backslash")]
    public void Test3()
    {
        const string INPUT = "\" \\ \"";

        var result = sut.StringToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value);
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse controls")]
    public void Test4()
    {
        const string INPUT = "\" \b\f\n\r\t \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse slash")]
    public void Test5()
    {
        const string INPUT = "\" / & / \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse alpha")]
    public void Test6()
    {
        const string INPUT = "\"abcdefghijklmnopqrstuvwyz\"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse ALPHA")]
    public void Test7()
    {
        const string INPUT = "\"ABCDEFGHIJKLMNOPQRSTUVWYZ\"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse digit")]
    public void Test8()
    {
        const string INPUT = "\" 0123456789 \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse word")]
    public void Test9()
    {
        const string INPUT = "\" digit \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse special")]
    public void Test10()
    {
        const string INPUT = "\" `1~!@#$%^&*()_+-={':[,]}|;.</>? \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse hex")]
    public void Test11()
    {
        const string INPUT = "\" ģ䕧覫췯ꯍ \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse address")]
    public void Test12()
    {
        const string INPUT = "\" 50 St. James Street \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse url")]
    public void Test13()
    {
        const string INPUT = "\" http://www.JSON.org/ \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }

    [TestMethod("Parse comment")]
    public void Test14()
    {
        const string INPUT = "\" // /* <!-- -- \"";

        var result = sut.GetToken().Parse(INPUT);

        if (result.Success)
        {
            Assert.IsTrue(result.Success);
            Assert.AreEqual(INPUT, result.Value.Show());
        }
        else
        {
            Assert.Fail(result.Error?.ToString());
        }
    }
}