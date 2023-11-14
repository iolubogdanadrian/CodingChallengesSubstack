using System.Collections.Immutable;

namespace CodingChallenges.ConverterJson.Models;

public class JsonArray : Json
{
    public ImmutableArray<Json> Elements { get; }

    public JsonArray(ImmutableArray<Json> elements)
    {
        Elements = elements;
    }

    public override object GetData()
    {
        if (Elements.Length == 0)
            return "[]";
        return $"[{string.Join(",", Elements.Select(e => e.GetData()))}]";
    }
}