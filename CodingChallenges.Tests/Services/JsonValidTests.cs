using CodingChallenges.ConverterJson.Services;

namespace CodingChallenges.Tests.Services;

[TestClass]
public class JsonValidTests
{
    private readonly JsonParser sut;

    // ReSharper disable once ConvertConstructorToMemberInitializers
    public JsonValidTests()
    {
        sut = new JsonParser();
    }

    [TestMethod("Parse a valid simple JSON object")]
    public void Test1()
    {
        const string json = "{}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
    }

    [TestMethod("Parse a key value line")]
    public void Test2()
    {
        const string json = "{\"key\": \"value\"}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key\":\"value\"}", result.Value.GetData() + "");
    }

    [TestMethod("Parse two lines")]
    public void Test3()
    {
        const string json = "{\"key\":\"value\",\"key2\":\"value\"}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key\":\"value\",\"key2\":\"value\"}", result.Value.GetData() + "");
    }

    [TestMethod("Parse bool type of value")]
    public void Test4()
    {
        const string json = "{\"key1\": true }";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":true}", result.Value.GetData() + "");
    }

    [TestMethod("Parse bool types of value")]
    public void Test5()
    {
        const string json = "{\"key1\":true,\"key2\":false}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":true,\"key2\":false}", result.Value.GetData() + "");
    }

    [TestMethod("Parse null type")]
    public void Test7()
    {
        const string json = "{\"key1\":null}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":null}", result.Value.GetData() + "");
    }

    [TestMethod("Parse int type")]
    public void Test8()
    {
        const string json = "{\"key1\":101}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":101}", result.Value.GetData() + "");
    }

    [TestMethod("Parse multiple types")]
    public void Test9()
    {
        const string json = "{\"key1\": true,\"key2\": false,\"key3\": null,\"key4\": \"value\",\"key5\": 101}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":true,\"key2\":false,\"key3\":null,\"key4\":\"value\",\"key5\":101}", result.Value.GetData() + "");
    }

    [TestMethod("Parse array type")]
    public void Test10()
    {
        const string json = "{\"key1\": []}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":[]}", result.Value.GetData() + "");
    }

    [TestMethod("Parse object type")]
    public void Test11()
    {
        const string json = "{\"key1\": {}}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key1\":{}}", result.Value.GetData() + "");
    }

    [TestMethod("Step 4 - valid.json")]
    public void Test12()
    {
        const string json = "{\"key\": \"value\",\r\n  \"key-n\": 101,\r\n  \"key-o\": {},\r\n  \"key-l\": []\r\n}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key\":\"value\",\"key-n\":101,\"key-o\":{},\"key-l\":[]}", result.Value.GetData() + "");
    }

    [TestMethod("Step 4 - valid2.json")]
    public void Test13()
    {
        const string json =
            "{\n  \"key\": \"value\",\n  \"key-n\": 101,\n  \"key-o\": {\n    \"inner key\": \"inner value\"\n  },\n  \"key-l\": [\"list value\"]\n}";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        Assert.AreEqual("{\"key\":\"value\",\"key-n\":101,\"key-o\":{\"inner key\":\"inner value\"},\"key-l\":[\"list value\"]}", result.Value.GetData() + "");
    }
}