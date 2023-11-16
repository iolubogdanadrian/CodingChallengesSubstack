using CodingChallenges.ConverterJson.Services;

namespace CodingChallenges.ConverterJson.Models;

public class JsonObject : Json
{
    public FifoDictionary<string, Json> Members { get; }

    public JsonObject(FifoDictionary<string, Json> members)
    {
        Members = members;
    }

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