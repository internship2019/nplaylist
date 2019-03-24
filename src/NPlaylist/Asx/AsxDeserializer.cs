using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace NPlaylist.Asx
{
    public class AsxDeserializer : IPlaylistDeserializer<AsxPlaylist>
    {
        public AsxPlaylist Deserialize(string input)
        {
            if (input == null)
                throw new InvalidAsxFormatException();

            var asxRawData = ConvertToAsxParts(input);
            return ConvertFromRawData(asxRawData);
        }

        private AsxParts.Asx ConvertToAsxParts(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(AsxParts.Asx));

            using (var reader = new StringReader(input))
            {
                try
                {
                    return xmlSerializer.Deserialize(reader) as AsxParts.Asx;
                }
                catch (Exception e)
                {
                    throw new InvalidAsxFormatException();
                }
            }
        }

        private AsxPlaylist ConvertFromRawData(AsxParts.Asx asxRawData)
        {
            var playlist = new AsxPlaylist();

            AddHead(playlist, asxRawData);
            AddItems(playlist, asxRawData.Entry);

            return playlist;
        }

        private void AddHead(AsxPlaylist playlist, AsxParts.Asx asxRawData)
        {
            playlist.Version = asxRawData.Version;
            playlist.Title = asxRawData.Title;
        }

        private void AddItems(AsxPlaylist playlist, List<AsxParts.Entry> entries)
        {
            foreach (var item in entries)
            {
                var asxItem = new AsxItem
                {
                    Title = item.Title,
                    Path = item.Ref?.Href,
                    Author = item.Author,
                    Copyright = item.Copyright
                };
                foreach (var itemTags in item.Param)
                {
                    asxItem.Tags[itemTags.Name] = itemTags.Value;
                }

                playlist.Add(asxItem);
            }
        }
    }
}
