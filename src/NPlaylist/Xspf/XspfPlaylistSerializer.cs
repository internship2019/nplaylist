using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace NPlaylist.Xspf
{
    public class XspfPlaylistSerializer : IPlaylistSerializer<XspfPlaylist>
    {
        public string Serialize(XspfPlaylist playlist)
        {
            if (playlist == null) return String.Empty;
            var helperPlaylist = FromXspfToHelper(playlist);
            return HelperToString(helperPlaylist);
        }

        private string HelperToString(XspfToXmlHelperClass.Playlist helperPlaylist)
        {
            var xmlSerializer = new XmlSerializer(typeof(XspfToXmlHelperClass.Playlist));
            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, helperPlaylist);
                return textWriter.ToString();
            }
        }

        private XspfToXmlHelperClass.Playlist FromXspfToHelper(XspfPlaylist playlist)
        {
            var helperPlaylist = new XspfToXmlHelperClass.Playlist();
           // helperPlaylist.Xmlns = playlist.Xmlns;
            helperPlaylist.Version = playlist.Version;
            helperPlaylist.TrackList = new XspfToXmlHelperClass.TrackList();
            helperPlaylist.TrackList.Track = new List<XspfToXmlHelperClass.Track>();
            foreach (var xspfPlaylistItem in playlist.Items)
            {
                helperPlaylist.TrackList.Track.Add(new XspfToXmlHelperClass.Track
                {
                    Title = xspfPlaylistItem.Title,
                    Location = xspfPlaylistItem.Path
                });
            }

            return helperPlaylist;

        }
    }
}
