using System;
using System.IO;
using System.Linq;
using NPlaylist.Asx;
using NPlaylist.M3u;
using NPlaylist.Pls;
using NPlaylist.Wpl;
using NPlaylist.Xspf;

namespace NPlaylist.Converter
{
    public static class ConversionTool
    {
        public static void Convert(
            TextReader inStream,
            TextWriter outStream,
            Format inputFormat,
            Format outputFormat)
        {
            if (inStream == null)
            {
                throw new ArgumentNullException(nameof(inStream));
            }

            if (outStream == null)
            {
                throw new ArgumentNullException(nameof(outStream));
            }

            var deserializer = GetDesrializer(inputFormat);
            var deserializedPlaylist = deserializer.Deserialize(inStream.ReadToEnd());
            var serializedPlaylist = SerializePlaylist(deserializedPlaylist, outputFormat);

            outStream.Write(serializedPlaylist);
        }

        private static IPlaylistDeserializer<IPlaylist> GetDesrializer(Format format)
        {
            switch (format)
            {
                case Format.XSPF:
                    return new XspfDeserializer();
                case Format.WPL:
                    return new WplDeserializer();
                case Format.ASX:
                    return new AsxDeserializer();
                case Format.PLS:
                    return new PlsDeserializer();
                case Format.M3U:
                    return new M3uDeserializer();
                default:
                    throw new ArgumentException($"{format}: Unsupported format");
            }
        }

        private static string SerializePlaylist(IPlaylist playlist, Format fileFormat)
        {
            switch (fileFormat)
            {
                case Format.XSPF:
                    var xspfSerializer = new XspfSerializer();
                    var xspfPl = new XspfPlaylist(playlist);
                    return xspfSerializer.Serialize(xspfPl);
                
                case Format.WPL:
                    var wplSerializer = new WplSerializer();
                    var wplPlaylist = new WplPlaylist(playlist);
                    return wplSerializer.Serialize(wplPlaylist);
                
                case Format.M3U:
                    var m3USerializer = new M3uSerializer();
                    var m3UPlaylist = new M3uPlaylist(playlist);
                    return m3USerializer.Serialize(m3UPlaylist);
                
                case Format.ASX:
                    var asxSerializer = new AsxSerializer();
                    var asxPlaylist = new AsxPlaylist(playlist);
                    return asxSerializer.Serialize(asxPlaylist);
                
                case Format.PLS:
                    var plsSerializer = new PlsSerializer();
                    var plsPlaylist = new PlsPlaylist(playlist);
                    return plsSerializer.Serialize(plsPlaylist);
            }

            return String.Empty;
        }

        private static Format GetFormatByExtension(string initialPlaylistPath)
        {
            var fileExtension = Path.GetExtension(initialPlaylistPath);

            if (fileExtension != null)
            {
                switch (fileExtension.ToLower())
                {
                    case ".wpl":
                        return Format.WPL;
                    case ".xspf":
                        return Format.XSPF;
                    case ".m3u":
                        return Format.M3U;
                    case ".m3u8":
                        return Format.M3U;
                    case ".asx":
                        return Format.ASX;
                    case ".pls":
                        return Format.PLS;
                    default:
                        return Format.Unknown;
                }
            }

            return Format.Unknown;
        }

        private static Format TryGetFormatByFirstLines(string path)
        {
            var firstTwoStrings = File
                .ReadLines(path)
                .Where(x => !string.IsNullOrEmpty(x))
                .Take(2).ToArray();

            if (firstTwoStrings.Length == 0)
            {
                throw new FormatException("File is empty");
            }

            if (firstTwoStrings.Contains("[playlist]"))
            {
                return Format.PLS;
            }

            if (firstTwoStrings[0].Contains("<?wpl"))
            {
                return Format.WPL;
            }

            if (firstTwoStrings[0].Contains("<asx"))
            {
                return Format.ASX;
            }

            if (firstTwoStrings[1].Contains("xmlns=\"http://xspf.org/ns/0/\""))
            {
                return Format.XSPF;
            }

            return Format.M3U;
        }
    }
}
