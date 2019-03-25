using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NPlaylist.Xspf
{
    public class XspfPlaylistSerializer : IPlaylistSerializer<XspfPlaylist>
    {
        public string Serialize(XspfPlaylist playlist)
        {
            if (playlist == null) return String.Empty;
            var helperPlaylist = FromXspfToHelper(playlist);
            return XspfHelperToString(helperPlaylist);
        }

        private string XspfHelperToString(XspfHelper.Playlist helperPlaylist)
        {
            var xmlSerializer = new XmlSerializer(typeof(XspfHelper.Playlist));
            using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
            {
                xmlSerializer.Serialize(stringWriter, helperPlaylist);

                return stringWriter.ToString();
            }
        }

        private XspfHelper.Playlist FromXspfToHelper(XspfPlaylist playlist)
        {
            var helperPlaylist = new XspfHelper.Playlist();
            helperPlaylist.Version = playlist.Version;
            helperPlaylist.TrackList = new XspfHelper.TrackList();
            helperPlaylist.TrackList.Track = new List<XspfHelper.Track>();

            foreach (var xspfPlaylistItem in playlist.Items)
            {
                helperPlaylist.TrackList.Track.Add(new XspfHelper.Track
                {
                    Title = xspfPlaylistItem.Title,
                    Location = xspfPlaylistItem.Path
                });
            }

            return helperPlaylist;
        }
    }
}
