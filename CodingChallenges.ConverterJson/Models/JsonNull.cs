namespace CodingChallenges.ConverterJson.Models;

public class JsonNull : Json
{
    public override object GetData() => "null";
}