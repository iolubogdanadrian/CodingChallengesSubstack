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

    [TestMethod("fail1.json")]
    public void Test6()
    {
        const string json = "\"A JSON payload should be an object or array, not a string.\"";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail2.json")]
    public void Test7()
    {
        const string json = "[\"Unclosed array\"";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail3.json")]
    public void Test8()
    {
        const string json = "{unquoted_key: \"keys must be quoted\"}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail4.json")]
    public void Test9()
    {
        const string json = "[\"extra comma\",]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail5.json")]
    public void Test10()
    {
        const string json = "[\"double extra comma\",,]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail6.json")]
    public void Test11()
    {
        const string json = "[   , \"<-- missing value\"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail7.json")] [Ignore]
    public void Test12()
    {
        const string json = "[\"Comma after the close\"],";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail8.json")] [Ignore]
    public void Test13()
    {
        const string json = "[\"Extra close\"]]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail9.json")] [Ignore]
    public void Test14()
    {
        const string json = "{\"Extra comma\": true,}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail10.json")] [Ignore]
    public void Test15()
    {
        const string json = "{\"Extra value after close\": true} \"misplaced quoted value\"";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail11.json")] [Ignore]
    public void Test16()
    {
        const string json = "{\"Illegal expression\": 1 + 2}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail12.json")] [Ignore]
    public void Test17()
    {
        const string json = "{\"Illegal invocation\": alert()}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail13.json")] [Ignore]
    public void Test18()
    {
        const string json = "{\"Numbers cannot have leading zeroes\": 013}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail14.json")] [Ignore]
    public void Test19()
    {
        const string json = "{\"Numbers cannot be hex\": 0x14}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail15.json")] [Ignore]
    public void Test20()
    {
        const string json = "[\"Illegal backslash escape: \\x15\"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail16.json")] [Ignore]
    public void Test21()
    {
        const string json = "[\\naked]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail17.json")] [Ignore]
    public void Test22()
    {
        const string json = "[\"Illegal backslash escape: \\017\"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail18.json")] [Ignore]
    public void Test23()
    {
        const string json = "[[[[[[[[[[[[[[[[[[[[\"Too deep\"]]]]]]]]]]]]]]]]]]]]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail19.json")] [Ignore]
    public void Test24()
    {
        const string json = "{\"Missing colon\" null}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail20.json")] [Ignore]
    public void Test25()
    {
        const string json = "{\"Double colon\":: null}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail21.json")] [Ignore]
    public void Test26()
    {
        const string json = "{\"Comma instead of colon\", null}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail22.json")] [Ignore]
    public void Test27()
    {
        const string json = "[\"Colon instead of comma\": false]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail23.json")] [Ignore]
    public void Test28()
    {
        const string json = "[\"Bad value\", truth]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail24.json")] [Ignore]
    public void Test29()
    {
        const string json = "['single quote']";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail25.json")] [Ignore]
    public void Test30()
    {
        const string json = "[\"\ttab\tcharacter\tin\tstring\t\"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail26.json")] [Ignore]
    public void Test31()
    {
        const string json = "[\"tab\\   character\\   in\\  string\\  \"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail27.json")] [Ignore]
    public void Test32()
    {
        const string json = "[\"line\nbreak\"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail28.json")] [Ignore]
    public void Test33()
    {
        const string json = "[\"line\\\nbreak\"]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail29.json")] [Ignore]
    public void Test34()
    {
        const string json = "[0e]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail30.json")] [Ignore]
    public void Test35()
    {
        const string json = "[0e+]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail31.json")] [Ignore]
    public void Test36()
    {
        const string json = "[0e+-1]";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail32.json")] [Ignore]
    public void Test37()
    {
        const string json = "{\"Comma instead if closing brace\": true,";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }

    [TestMethod("fail33.json")] [Ignore]
    public void Test38()
    {
        const string json = "[\"mismatch\"}";

        var result = sut.Parse(json);

        Assert.IsFalse(result.Success);
    }
}