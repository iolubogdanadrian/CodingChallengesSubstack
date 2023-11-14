using System;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

#pragma warning disable CS8321 // Local function is declared but never used

// We'll be parsing strings - sequences of characters.

// For other applications (eg parsing binary file formats) TToken may be some other type (eg byte).
namespace LearningPhase;

internal class Program
{
    private static void Main(string[] args)
    {
        /*
         * Verify type bool
         */
        var boolParser = String("true").Or(String("false")).Select(bool.Parse);
        var resultTrue = boolParser.ParseOrThrow("true");
        var resultFalse = boolParser.ParseOrThrow("false");
        Console.WriteLine(resultTrue);
        Console.WriteLine(resultFalse);

        //

        var parser2 = String("true").Or(String("false")).Select(bool.Parse);
        var rs = parser2.ParseOrThrow("true");
        Console.WriteLine("result:" + rs);


        /*
         * Between
         */
        var a = Char('[');
        var b = Char(']');
        var content = Token(it => it != '[' && it != ']').ManyString();
        var resultB = content.Between(a, b);

        var result = resultB.ParseOrThrow("[Hello,World!]");
        Console.WriteLine(result);
        // var parser = Char('a');
        // var test1 = parser.ParseOrThrow("a");


        // var test = parser.ParseOrThrow("b");

        // var parser1 = String("foo");
        // var parser2 = String("bar");
        // var sequencedParser = parser1.Then(parser2);
        // Console.WriteLine("bar: " + sequencedParser.ParseOrThrow("foobar")); // "foo" got thrown away
        // Console.WriteLine(sequencedParser.ParseOrThrow("food"));

        // var parser1 = String("foo");
        // var parser2 = String("bar");
        // var sequencedParser = parser1.Before(parser2);
        // Console.WriteLine("foo: " + sequencedParser.ParseOrThrow("foobar")); // "bar" got thrown away
        // Assert.Throws<ParseException>(() => sequencedParser.ParseOrThrow("food"));

        /*
         * Map does a similar job, except it keeps both results and applies a transformation function to them
         */
        // var parser1 = String("foo");
        // var parser2 = String("bar");
        // var sequencedParser = Map((foo, bar) => TransformationFunction(bar, foo), parser1, parser2);
        // Console.WriteLine("bartestfoo:" + sequencedParser.ParseOrThrow("foobar"));
        // Console.WriteLine(sequencedParser.ParseOrThrow("food"));

        /*
         * Bind uses the result of a parse to choose the next parser.
         * Parse any character, then parse a character matching the first character
         */
        // Parser<char, char> parser = Any.Bind(c => Char(c));
        // Assert.AreEqual('a', parser.ParseOrThrow("aa"));
        // Assert.AreEqual('b', parser.ParseOrThrow("bb"));
        // Assert.Throws<ParseException>(() => parser.ParseOrThrow("ab"));

        /*
         * If one of Or or OneOf's component parsers fails after consuming input, the whole parser will fail.
         */
        // var parser = OneOf(String("foo"), String("bar"));

        /*
         * Recursive grammars:
         *      A recursive referral to a variable currently being initialised will return null.
         */
        // Parser<char, char> expr = null;
        // var parenthesised = Char('(')
        //     .Then(Rec(() => expr)) // using a lambda to (mutually) recursively refer to expr
        //     .Before(Char(')'));
        // expr = Digit.Or(parenthesised);
        // Console.WriteLine(expr.ParseOrThrow("(3)"));
        // Console.WriteLine(expr.ParseOrThrow("(1)"));
        // Console.WriteLine(expr.ParseOrThrow("(((1)))"));

        //var parserT = Char('a');
        //var beforeT = Char('b');
        //var afterT = Char('c');
        //var inBraces = InBraces(parserT, beforeT, afterT);
        //var result = inBraces.ParseOrThrow("bac");
        //Console.WriteLine(result);
        Console.ReadLine();
        return;

        string TransformationFunction(string bar, string foo) =>
            $"{bar}test{foo}";

        Parser<TToken, T> InBraces<TToken, T, U, V>(Parser<TToken, T> parser, Parser<TToken, U> before, Parser<TToken, V> after)
            => before.Then(parser).Before(after);
    }

    //private Parser<char, Json> JsonParserLeftBracket() => StructureJson()
    //    .Map(it => (Json) new JsonString(it));

    //private Parser<char, string> StructureJson()
    //{
    //    var leftBracket = Char('{');
    //    var rightBracket = Char('}');
    //    var content = Token(it => it != '{' && it != '}').ManyString();
    //    return content.Between(leftBracket, rightBracket);
    //}
}