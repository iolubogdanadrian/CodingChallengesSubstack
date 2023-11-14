namespace CodingChallenges.Library.Helpers;

public static class Extensions
{
    public static bool IsEqualTo(this string s1, string s2) => s1.EmptyIfNull().Trim() == s2.EmptyIfNull().Trim();
    public static bool IsNumeric(this string s) => decimal.TryParse(s, out _);
    public static bool IsInteger(this string s) => int.TryParse(s, out _);

    public static string EmptyIfNull(this string s) => s ?? "";
}