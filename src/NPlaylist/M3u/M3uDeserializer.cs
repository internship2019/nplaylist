using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using NPlaylist.M3u.Exceptions;

namespace NPlaylist.M3u
{
    public class M3uDeserializer : IPlaylistDeserializer<M3uPlaylist>
    {
        public M3uPlaylist Deserialize(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            input = TransformStringToUseUnixNewlines(input);

            if (!M3uRegexConsts.startsWithHeaderRegex.IsMatch(input))
            {
                throw new FormatException();
            }

            var m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.AddRange(ExtractMediaItems(input));

            return m3uPlaylist;
        }

        private string TransformStringToUseUnixNewlines(string str)
        {
            return str.Replace("\r\n", "\n");
        }

        private IEnumerable<M3uItem> ExtractMediaItems(string mediaItemsPart)
        {
            int mediaIndex = 0;

            foreach (Match rawMediaMatch in M3uRegexConsts.rawMediaRegex.Matches(mediaItemsPart))
            {
                mediaIndex++;

                var mediaMatch = M3uRegexConsts.mediaRegex.Match(rawMediaMatch.Value);
                if (!mediaMatch.Success)
                {
                    throw new MediaFormatException($"Media {mediaIndex} is not well formated");
                }

                yield return MediaMatchToM3uItem(mediaMatch, mediaIndex);
            }
        }

        private M3uItem MediaMatchToM3uItem(Match mediaMatch, int mediaIndex)
        {
            return new M3uItem(ExtractPath(mediaMatch, mediaIndex))
            {
                Duration = ExtractDuration(mediaMatch),
                Title = ExtractTitle(mediaMatch)
            };
        }

        private string ExtractPath(Match mediaMatch, int mediaIndex)
        {
            var path = mediaMatch.Groups["path"].Value;

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new MediaFormatException($"Media {mediaIndex} does not contain a valid path");
            }

            return path;
        }

        private decimal ExtractDuration(Match mediaMatch)
        {
            var durationStr = mediaMatch.Groups["duration"].Value;
            return decimal.Parse(durationStr, CultureInfo.InvariantCulture);
        }

        private string ExtractTitle(Match mediaMatch)
        {
            var title = mediaMatch.Groups["title"].Value;

            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            return title;
        }
    }
}
