namespace CodingChallenges.ConverterJson.Models;

public class NumericToken(double value) : BaseToken
{
    public double Value { get; } = value;

    public override object Show() => Value;
}