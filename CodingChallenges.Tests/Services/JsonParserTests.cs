using CodingChallenges.ConverterJson.Services;

namespace CodingChallenges.Tests.Services;

[TestClass]
public class JsonParserTests
{
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
    }

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
    }
}