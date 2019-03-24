using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NPlaylist.Asx
{
    public class AsxSerializer : IPlaylistSerializer<AsxPlaylist>
    {
        public string Serialize(AsxPlaylist playlist)
        {
            if (playlist == null)
                return String.Empty;
            var asxObject = ConvertToAsxParts(playlist);
            return ConvertToRawData(asxObject);
        }

        private AsxParts.Asx ConvertToAsxParts(AsxPlaylist playlist)
        {
            var objectPlaylist = new AsxParts.Asx
            {
                Version = playlist.Version,
                Title = playlist.Title,
                Entry = new List<AsxParts.Entry>()
            };
            foreach (var item in playlist.Items)
            {
                var asxItem = new AsxParts.Entry
                {
                    Author = item.Author,
                    Copyright = item.Copyright,
                    Title = item.Title
                };
                asxItem.Ref = new AsxParts.Ref
                {
                    Href = item.Path
                };
                asxItem.Param = new List<AsxParts.ParamItem>();
                foreach (var itemTags in item.Tags.Skip(4))
                {
                    asxItem.Param.Add(new AsxParts.ParamItem
                    {
                        Name = itemTags.Key,
                        Value = itemTags.Value
                    });
                }
                objectPlaylist.Entry.Add(asxItem);
            }
            return objectPlaylist;
        }

        private string ConvertToRawData(AsxParts.Asx asxObject)
        {
            var xmlSerializer = new XmlSerializer(typeof(AsxParts.Asx));
            using (var textWriter = new StringWriter())
            {
                try
                {
                    xmlSerializer.Serialize(textWriter, asxObject);
                    return textWriter.ToString();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
