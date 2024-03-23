namespace CodingChallenges.ConverterJson.Models;

public class BoolToken(bool value) : BaseToken
{
    public bool Value { get; } = value;

    public override object Show() => $"{Value}".ToLower();
}