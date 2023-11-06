using Pidgin;

namespace CodingChallenges.ConverterJson.Helpers;

public static class Extensions
{
    public static Parser<TToken, T> InBraces<TToken, T, U, V>(this Parser<TToken, T> parser, Parser<TToken, U> before, Parser<TToken, V> after)
        => before
            .Then(parser)
            .Before(after);
}