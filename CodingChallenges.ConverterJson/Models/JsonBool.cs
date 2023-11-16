namespace CodingChallenges.ConverterJson.Models;

public class JsonBool : Json
{
    public bool Value { get; }

    public JsonBool(bool value)
    {
        Value = value;
    }

    public override object Show() => $"{Value}".ToLower();
}