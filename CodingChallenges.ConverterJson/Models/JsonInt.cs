namespace CodingChallenges.ConverterJson.Models;

public class JsonInt : Json
{
    public int Value { get; }

    public JsonInt(int value)
    {
        Value = value;
    }

    public override object GetData() => Value;
}