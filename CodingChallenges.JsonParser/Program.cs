using CodingChallenges.ConverterJson.Services;

var json = "{\"key\": \"value\",\"key2\": \"value\"}";
var jsonParser = new JsonParser().Parse(json);
Console.WriteLine(jsonParser.Value);
Console.ReadLine();
