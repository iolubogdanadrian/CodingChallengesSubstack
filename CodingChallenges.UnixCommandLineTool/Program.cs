using System.Globalization;
using CodingChallenges.Library.Models;
using CodingChallenges.Library.Services;
using CodingChallenges.Monads.Services;

Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

var tool = new UnixCommandService(new SafeFileSystemDecorator(new FileSystem()));

var readLine = IO<string>.Of(() => Console.ReadLine() ?? throw new Exception("Missing command"));
var result = tool.Apply(new Command(readLine.UnsafePerformIO()));
Console.WriteLine(result);
Console.ReadLine();
