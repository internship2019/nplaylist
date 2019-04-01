using System;
using System.IO;
using System.Linq;
using NPlaylist;
using NPlaylist.Asx;
using NPlaylist.M3u;
using NPlaylist.Pls;
using NPlaylist.Wpl;
using NPlaylist.Xspf;

namespace NPlaylist.Player
{
    public static class Playlist
    {
        public static IPlaylist Read(string initialPlaylistPath)
        {
            if (string.IsNullOrWhiteSpace(initialPlaylistPath))
            {
                throw new ArgumentNullException(nameof(initialPlaylistPath));
            }

            var inputFormat = GetFormat(initialPlaylistPath);
            var deserializer = GetDesrializer(inputFormat);
            var deserializedPlaylist = ReadPlaylist(initialPlaylistPath, deserializer);
            return deserializedPlaylist;
        }

        private static Format GetFormat(string path)
        {
            var fileFormat = GetFormatByExtension(path);
            if (fileFormat == Format.Unknown)
            {
                fileFormat = TryGetFormatByFirstLines(path);
            }

            return fileFormat;
        }

        private static IPlaylist ReadPlaylist(string path, IPlaylistDeserializer<IPlaylist> deserializer)
        {
            using (var streamReader = new StreamReader(path))
            {
                return deserializer.Deserialize(streamReader.ReadToEnd());
            }
        }

        private static IPlaylistDeserializer<IPlaylist> GetDesrializer(Format fileFormat)
        {
            switch (fileFormat)
            {
                case Format.XSPF:
                    return new XspfDeserializer();
                case Format.WPL:
                    return new WplDeserializer();
                case Format.ASX:
                    return new AsxDeserializer();
                case Format.PLS:
                    return new PlsDeserializer();
                default:
                    return new M3uDeserializer();
            }
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
