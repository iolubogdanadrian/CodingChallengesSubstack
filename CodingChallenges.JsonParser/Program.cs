using CodingChallenges.ConverterJson.Services;

var json = "{}";
var jsonParser = new JsonParser().Parse(json);
Console.WriteLine(jsonParser.Value);
Console.ReadLine();
