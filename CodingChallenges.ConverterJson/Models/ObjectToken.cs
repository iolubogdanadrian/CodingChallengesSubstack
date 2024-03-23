using CodingChallenges.ConverterJson.Services;

namespace CodingChallenges.ConverterJson.Models;

public class ObjectToken(FifoDictionary<string, BaseToken> members) : BaseToken
{
    public FifoDictionary<string, BaseToken> Members { get; } = members;

    public override object Show()
    {
        var list = new List<string>();
        while (Members.Count > 0)
        {
            var item = Members.Dequeue();
            var result = $"\"{item.Key}\":{item.Value.Show()}";
            list.Add(result);
        }

        return $"{{{string.Join(",", list)}}}";
    }
}