
using CodingChallenges.Library.Models;
using CodingChallenges.Library.Services;

var tool = new UnixCommandService(new FileSystem());

var input = Console.ReadLine() ?? throw new Exception("Missing command");
var result = tool.Apply(new Command(input));
Console.WriteLine(result);
Console.ReadLine();
