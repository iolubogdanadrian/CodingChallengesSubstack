namespace CodingChallenges.ConverterJson.Models;

public class JsonNumeric : Json
{
    public int Value { get; }

    public JsonNumeric(int value)
    {
        Value = value;
    }

    public override object Show() => Value;
}