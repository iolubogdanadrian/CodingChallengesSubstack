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
            var json = "{}";

            var result = sut.Parse(json);

            Assert.IsTrue(result.Success);
        }

        [TestMethod("Parse a key value line")]
        public void Test2()
        {
            var json = "{\"key\": \"value\"}";

            var result = sut.Parse(json);

            Assert.IsTrue(result.Success);
            Assert.AreEqual("{\"key\": \"value\"}", result.Value.ToString());
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
            var json = "";

            var result = sut.Parse(json);

            Assert.IsFalse(!result.Success);
        }
    }
}