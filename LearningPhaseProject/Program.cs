using Pidgin;
using static Pidgin.Parser<char>;
using static Pidgin.Parser;


var result = StringToken().ParseOrThrow(".");
Console.WriteLine(result);
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