namespace CodingChallenges.ConverterJson.Services;

public record StringNode(string Name, string Value) : JsonNode<string>(Name, Value);