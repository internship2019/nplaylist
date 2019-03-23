using System;
using System.IO;
using System.Xml.Serialization;

namespace NPlaylist.Xspf
{
    public class XspfPlaylistDesrializer : IPlaylistDeserializer<XspfPlaylist>
    {
        public XspfPlaylist Deserialize(string input)
        {
            if (input == null)
                return new XspfPlaylist();
            var helperPlaylist = ToXmlHelperClass(input);
            return ConvertToXspfPlaylist(helperPlaylist);
        }

        private XspfToXmlHelperClass.Playlist ToXmlHelperClass(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(XspfToXmlHelperClass.Playlist));

            using (var reader = new StringReader(input))
            {
                try
                {
                    return xmlSerializer.Deserialize(reader) as XspfToXmlHelperClass.Playlist;
                }
                catch (InvalidOperationException)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private XspfPlaylist ConvertToXspfPlaylist(XspfToXmlHelperClass.Playlist playlist)
        {
            var xspfPlaylist = new XspfPlaylist();
            xspfPlaylist.Version = playlist.Version;
            //xspfPlaylist.Xmlns = playlist.Xmlns;

            foreach (var track in playlist.TrackList.Track)
            {
                xspfPlaylist.Add(new XspfPlaylistItem
                {
                    Path = track.Location,
                    Title = track.Title
                });
            }

            return xspfPlaylist;
        }
    }
}
