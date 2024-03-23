using CodingChallenges.ConverterJson.Services.Parsers;
using Pidgin;
using static Pidgin.Parser<char>;
using static Pidgin.Parser;

#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable CS0162 // Unreachable code detected

// ReSharper disable All


// var result = StringToken().ParseOrThrow(".");
var result = new StringParser().GetToken().Parse("\" \"");
if (result.Success)
{
    Console.WriteLine("Success");
    var value = result.Value.Show();
    Console.WriteLine(value);
}
else
{
    Console.WriteLine("Failed");
    var resultError = result.Error;
    Console.WriteLine(resultError);
}

Console.ReadLine();
return;

static Parser<char, string> StringToken()
{
    return Token(c => char.IsPunctuation(c)).ManyString();
    return Char('"')
        .Then(Token(c => char.IsPunctuation(c)).ManyString())
        .Then(Char('"'))
        .ManyString();
}

// Parser<char, string> StringToken2() => Char('"')
//     .Then(Token(c => c != '"').ManyString()) //Token(c => char.IsPunctuation(c) || char.IsPunctuation(c) || char.IsLetterOrDigit(c) || c <= 127)
//     .Before(Char('"'));