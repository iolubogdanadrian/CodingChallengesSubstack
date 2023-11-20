using System.Globalization;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

var culture = CultureInfo.InvariantCulture;

// var test1 = decimal.Parse("123.45", culture);
var result = NumericToken().ParseOrThrow("5.6");
Console.WriteLine(result);
Console.ReadLine();
return;

Parser<char, double> NumericToken() => DecimalBeforeString()
    .Before(SkipWhitespaces)
    .Select(it => (double) decimal.Parse(it, culture));

static Parser<char, string> DecimalBeforeString() =>
    Token(c => char.IsDigit(c) || c == '-' || c == '+' || c == '.')
        .AtLeastOnce()
        .Select(chars => new string(chars.ToArray()));