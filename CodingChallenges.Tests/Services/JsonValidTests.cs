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

    [TestMethod("Step 5 - pass1.json")]
    public void Test14()
    {
        const string json =
            "[\n    \"JSON Test Pattern pass1\",\n    {\"object with 1 member\":[\"array with 1 element\"]},\n    {},\n    [],\n    -42,\n    true,\n    false,\n    null,\n    {\n        \"integer\": 1234567890,\n        \"real\": -9876.543210,\n        \"e\": 0.123456789e-12,\n        \"E\": 1.234567890E+34,\n        \"\":  23456789012E66,\n        \"zero\": 0,\n        \"one\": 1,\n        \"space\": \" \",\n        \"quote\": \"\\\"\",\n        \"backslash\": \"\\\\\",\n        \"controls\": \"\\b\\f\\n\\r\\t\",\n        \"slash\": \"/ & \\/\",\n        \"alpha\": \"abcdefghijklmnopqrstuvwyz\",\n        \"ALPHA\": \"ABCDEFGHIJKLMNOPQRSTUVWYZ\",\n        \"digit\": \"0123456789\",\n        \"0123456789\": \"digit\",\n        \"special\": \"`1~!@#$%^&*()_+-={':[,]}|;.</>?\",\n        \"hex\": \"\\u0123\\u4567\\u89AB\\uCDEF\\uabcd\\uef4A\",\n        \"true\": true,\n        \"false\": false,\n        \"null\": null,\n        \"array\":[  ],\n        \"object\":{  },\n        \"address\": \"50 St. James Street\",\n        \"url\": \"http://www.JSON.org/\",\n        \"comment\": \"// /* <!-- --\",\n        \"# -- --> */\": \" \",\n        \" s p a c e d \" :[1,2 , 3\n\n,\n\n4 , 5        ,          6           ,7        ],\"compact\":[1,2,3,4,5,6,7],\n        \"jsontext\": \"{\\\"object with 1 member\\\":[\\\"array with 1 element\\\"]}\",\n        \"quotes\": \"&#34; \\u0022 %22 0x22 034 &#x22;\",\n        \"\\/\\\\\\\"\\uCAFE\\uBABE\\uAB98\\uFCDE\\ubcda\\uef4A\\b\\f\\n\\r\\t`1~!@#$%^&*()_+-=[]{}|;:',./<>?\"\n: \"A key can be any string\"\n    },\n    0.5 ,98.6\n,\n99.44\n,\n\n1066,\n1e1,\n0.1e1,\n1e-1,\n1e00,2e+00,2e-00\n,\"rosebud\"]";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        // Assert.AreEqual("", result.Value.GetData() + "");
    }

    [TestMethod("Step 5 - pass2.json")]
    public void Test15()
    {
        const string json =
            "[[[[[[[[[[[[[[[[[[[\"Not too deep\"]]]]]]]]]]]]]]]]]]]";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        // Assert.AreEqual("", result.Value.GetData() + "");
    }

    [TestMethod("Step 5 - pass3.json")]
    public void Test16()
    {
        const string json =
            "{\n    \"JSON Test Pattern pass3\": {\n        \"The outermost value\": \"must be an object or array.\",\n        \"In this test\": \"It is an object.\"\n    }\n}\n";

        var result = sut.Parse(json);

        Assert.IsTrue(result.Success);
        // Assert.AreEqual("", result.Value.GetData() + "");
    }
}