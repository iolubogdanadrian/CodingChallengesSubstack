using System.Collections.Immutable;

namespace CodingChallenges.ConverterJson.Models;

public class ArrayToken(ImmutableArray<BaseToken> elements) : BaseToken
{
    public ImmutableArray<BaseToken> Elements { get; } = elements;

    public override object Show() => Elements.Length == 0
        ? "[]"
        : $"[{string.Join(",", Elements.Select(e => e.Show()))}]";
}