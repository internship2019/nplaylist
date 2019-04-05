using System;
using CommandLine;

namespace NPlaylist.Converter
{
    class Program
    {
        public class ArgOptions
        {
            [Option("from_format", Required = true, HelpText = "Format to convert from")]
            public Format InputFormat { get; set; }

            [Option("to_format", Required = true, HelpText = "Format to convert to")]
            public Format OutputFormat { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<ArgOptions>(args)
                .WithParsed(options => WithValidOptions(options));
        }

        private static void WithValidOptions(ArgOptions argOptions)
        {
            try
            {
                ConversionTool.Convert(Console.In, Console.Out, argOptions.InputFormat, argOptions.OutputFormat);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"[Failed]: {e.Message}");
            }
        }
    }
}
