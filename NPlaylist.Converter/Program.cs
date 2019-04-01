using System;

namespace NPlaylist.Converter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "-h" || args[0] == "--help")
            {
                PrintHelp();
                return 0;
            }

            if (args.Length != 3)
            {
                Console.Error.WriteLine("Wrong number of arguments");
                return -1;
            }

            var format = GetFormat(args[2]);
            if (format == Format.Unknown)
            {
                Console.Error.WriteLine($"Unsupported format: {args[2].ToLower()}");
                return -1;
            }

            try
            {
                ConversionTool.Convert(args[0], args[1], format);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return -1;
            }

            return 0;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Arguments: <source file> <destination file> <format>");
            Console.WriteLine("Supported formats: wpl, xspf, pls, m3u, asx");
        }

        public static Format GetFormat(string input)
        {
            switch (input.ToLower())
            {
                case "wpl":
                    return Format.WPL;
                case "asx":
                    return Format.ASX;
                case "m3u":
                    return Format.M3U;
                case "xspf":
                    return Format.XSPF;
                case "pls":
                    return Format.PLS;
                default:
                    return Format.Unknown;
            }
        }
    }
}
