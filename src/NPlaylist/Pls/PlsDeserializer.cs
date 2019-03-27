using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NPlaylist.Pls.Helper;

namespace NPlaylist.Pls
{
    public class PlsDeserializer : IPlaylistDeserializer<PlsPlaylist>
    {
        private const string locationPattern = @".+";
        private const string titlePattern = @".+";
        private const string lengthPattern = @"-?\d+";
        private const string versionPattern = @"Version=(\d)";

        private static readonly Regex entryGroupRegex = new Regex(
            $@"File\d+=({locationPattern})\n?"
            + $@"(?:Title\d+=({titlePattern})\n?)?"
            + $@"(?:Length\d+=({lengthPattern})\n?)?");

        public PlsPlaylist Deserialize(string input)
        {
            ValidateInputFormat(input);

            var playlist = new PlsPlaylist();

            AddPlaylistVersion(playlist, input);
            AddPlaylistItems(playlist, input);

            return playlist;
        }

        private void AddPlaylistVersion(PlsPlaylist playlist, string input)
        {
            var match = Regex.Match(input, versionPattern).Groups[1].Value;

            playlist.Version = match;
        }

        private void AddPlaylistItems(PlsPlaylist playlist, string input)
        {
            input = StringUtils.RemoveMetaLines(input);
            var items = ExtractItems(input);

            foreach (var item in items)
            {
                playlist.Add(item);
            }
        }

        private List<PlsItem> ExtractItems(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<PlsItem>();
            }
            var items = new List<PlsItem>();
            
            var lines = Regex.Split(StringUtils.RemoveEmptyLines(input), @"\n\n");

            foreach (var line in lines)
            {
                items.Add(GetOneItem(line));
            }

            return items;
        }

        private PlsItem GetOneItem(string block)
        {
            var match = entryGroupRegex.Match(block);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var path = match.Groups[1].Value;
            var title = match.Groups[2].Value;
            var length = match.Groups[3].Value;

            return new PlsItem(path)
                {
                    Title = title,
                    Length = length
                };
        }

        private void ValidateInputFormat(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException();
            }

            if (!StringUtils.InputHeaderValidation(input))
            {
                throw new FormatException();
            }
        }
    }
}
