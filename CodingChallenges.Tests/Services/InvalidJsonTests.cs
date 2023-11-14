using CodingChallenges.ConverterJson.Services;

namespace CodingChallenges.Tests.Services;

[TestClass]
public class InvalidJsonTests
{
    private readonly JsonParser sut;

    // ReSharper disable once ConvertConstructorToMemberInitializers
    public InvalidJsonTests()
    {
        sut = new JsonParser();
    }

    [TestMethod("Parse a invalid JSON object")]
    public void Test1()
    {
        const string json = "";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("Extra Comma")]
    public void Test2()
    {
        const string json = "{\"key\": \"value\",}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("Missing Quotes")]
    public void Test3()
    {
        const string json = "{\"key\": \"value\",key2: \"value\"\n}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("Upper Letter Boolean type")]
    public void Test4()
    {
        const string json = "{\n  \"key1\": true,\n  \"key2\": False,\n  \"key3\": null,\n  \"key4\": \"value\",\n  \"key5\": 101\n}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("Test for Step4 invalid.json")]
    public void Test5()
    {
        const string json =
            "{\"key\":\"value\",\"key-n\":101,\"key-o\": {\"inner key\":\"inner value\"},\"key-l\": ['list value']}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }
}