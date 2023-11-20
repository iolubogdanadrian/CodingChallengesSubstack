using System.Globalization;

namespace CodingChallenges.Library;

public class Constants
{
    public static CultureInfo CULTURE = new("en-US");

    public const string COMMAND_SYNTAX = "ccwc";
    public const string OPTION_NUMBER_OF_BYTES = "-c";
    public const string OPTION_NUMBER_OF_LINES = "-l";
    public const string OPTION_NUMBER_OF_WORDS = "-w";
    public const string OPTION_NUMBER_OF_CHARACTERS = "-m";
}