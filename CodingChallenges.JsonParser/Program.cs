using CodingChallenges.ConverterJson.Services;

const string json = "{\"key1\":101}";
var jsonParser = new JsonParser().Parse(json);
Console.WriteLine($"Expected: {{\"key1\":101}}\r\n Result: {jsonParser.Value.Show()}");
Console.ReadLine();
