namespace CodingChallenges.ConverterJson.Models;

public class JsonNumeric : Json
{
    public double Value { get; }

    public JsonNumeric(double value)
    {
        Value = value;
    }

    public override object Show() => Value;
}