using CodingChallenges.ConverterJson.Contracts;
using CodingChallenges.ConverterJson.Services;
using CodingChallenges.ConverterJson.Services.Parsers;

const string json = "{\"key1\":101}";
// const string json = "{}";

var objectParser = new ObjectParser();
var arrayParser = new ArrayParser();
var parsers = new List<ITokenParser>
{
    new NumericParser(),
    new BoolParser(),
    new StringParser(),
    new NullParser(),
    objectParser,
    arrayParser,
};

var parser = new ParserMultipleTypes(parsers);
objectParser.Parsers = parser;
arrayParser.Parsers = parser;

var tokenParsers = new List<ITokenParser>()
{
    objectParser,
    arrayParser,
};
var jsonParser = new JsonParser(tokenParsers).Parse(json);
Console.WriteLine($"Expected: {{\"key1\":101}}\r\n Result: {jsonParser.Value.Show()}");
Console.ReadLine();