using System.Collections.Immutable;

namespace CodingChallenges.ConverterJson.Models;

public class JsonObject : Json
{
    public IImmutableDictionary<string, Json> Members { get; }

    public JsonObject(IImmutableDictionary<string, Json> members)
    {
        Members = members;
    }

    public override string ToString()
        => $"{{{string.Join(",", Members.Select(kvp => $"\"{kvp.Key}\":{kvp.Value}"))}}}";
}