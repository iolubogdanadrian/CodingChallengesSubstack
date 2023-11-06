namespace CodingChallenges.ConverterJson.Models;

public class JsonString : Json
{
    public string Value { get; }

    public JsonString(string value)
    {
        Value = value;
    }

    public override string ToString()
        => $"\"{Value}\"";
}