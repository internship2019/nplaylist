using System;
using System.Text.RegularExpressions;

namespace NPlaylist.M3u
{
    internal static class M3uRegexConsts
    {
        public const string decimalPattern = @"\d+(?:\.\d+)?";
        public const string argSepPattern = @"(?:\ *,\ *)";

        public static readonly string mediaHeaderPattern = $@"#
            \#EXTINF:                                   # Media header
                (?<duration>{decimalPattern})           # Capture duration
                (?(?={argSepPattern})                   # If arg separation found
                    (?:{argSepPattern}(?<title>.+)))    #  then capture title (without arg sep)
        ";

        public static readonly Regex mediaRegex = new Regex($@"#
            {mediaHeaderPattern}\n      # Capture elements from media header
            (?<path>.+)(?:\n|$)         # Capture the media's path
        ", RegexOptions.IgnorePatternWhitespace);

        public static readonly string rawMediaPattern = $@"#
            \#EXTINF:.*\n       #
            .*(?:\n|$)          #
        ";

        public static readonly Regex rawMediaRegex = new Regex(
            rawMediaPattern,
            RegexOptions.IgnorePatternWhitespace);

        public static readonly Regex startsWithHeaderRegex = new Regex("^#EXTM3U(\n|$)");
    }
}
