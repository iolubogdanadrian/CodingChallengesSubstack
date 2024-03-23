namespace CodingChallenges.ConverterJson.Models;

public class StringToken(string value) : BaseToken
{
    public string Value { get; } = value;

    public override object Show() => $"\"{Value}\"";
}