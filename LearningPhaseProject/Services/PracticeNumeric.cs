using System.Globalization;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

// ReSharper disable All

namespace LearningPhaseProject.Services;

internal class PracticeNumeric
{
    public void Test()
    {
        // var inputString = "1.23456789e-13";
        // var result2 = double.Parse(inputString, CultureInfo.InvariantCulture);
        // // Console.WriteLine(result2);

        CultureInfo CULTURE = new("en-US");

        var result = NumericToken().ParseOrThrow("1.23456789e34"); //"1.23456789e-13"
        Console.WriteLine(result);
    }


    private Parser<char, double> NumericToken() => DecimalBeforeString()
        .Before(SkipWhitespaces)
        .Select(
            it =>
            {
                var result = TryParseCustom(it);

                return result;
            });

    private static bool TryParseScientificNotation(string input, out decimal result)
    {
        var formatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ".",
            PositiveSign = "+",
            NegativeSign = "-",
        };

        return decimal.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands | NumberStyles.AllowExponent, formatInfo, out result);
    }

    private static double TryParseCustom(string input)
    {
        var parts = input.Split('e', 'E');

        if (parts.Length != 2)
            return 0;

        if (double.TryParse(parts[0], out var coefficient) && int.TryParse(parts[1], out var exponent))
            return coefficient * Math.Pow(10, exponent);

        return 0;
    }

    private static Parser<char, string> DecimalBeforeString() =>
        Token(c => char.IsDigit(c) || c == '-' || c == '+' || c == '.' || c == 'e' || c == 'E')
            .AtLeastOnce()
            .Select(chars => new string(chars.ToArray()));
}