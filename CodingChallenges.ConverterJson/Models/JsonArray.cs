using System.Collections.Immutable;

namespace CodingChallenges.ConverterJson.Models;

public class JsonArray : Json
{
    public ImmutableArray<Json> Elements { get; }

    public JsonArray(ImmutableArray<Json> elements)
    {
        Elements = elements;
    }

    public override string ToString()
        => $"[{string.Join(",", Elements.Select(e => e.ToString()))}]";
}