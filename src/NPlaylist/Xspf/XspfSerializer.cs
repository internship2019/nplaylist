using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NPlaylist.Xspf.XspfHelper;

namespace NPlaylist.Xspf
{
    public class XspfSerializer : IPlaylistSerializer<XspfPlaylist>
    {
        public string Serialize(XspfPlaylist playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException("playlist is null");
            }
            var helperPlaylist = FromXspfToHelper(playlist);
            return XspfHelperToString(helperPlaylist);
        }

        private string XspfHelperToString(XspfHelperPlaylist helperPlaylist)
        {
            var xmlSerializer = new XmlSerializer(typeof(XspfHelperPlaylist));
            using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
            {
                xmlSerializer.Serialize(stringWriter, helperPlaylist);

                return stringWriter.ToString();
            }
        }

        private XspfHelperPlaylist FromXspfToHelper(XspfPlaylist playlist)
        {
            var helperPlaylist = new XspfHelperPlaylist();
            helperPlaylist.Version = playlist.Version;
            helperPlaylist.TrackList = new XspfHelperTrackList();
            helperPlaylist.TrackList.Track = new List<XspfHelperTrack>();

            foreach (var xspfPlaylistItem in playlist.Items)
            {
                helperPlaylist.TrackList.Track.Add(new XspfHelperTrack
                {
                    Title = xspfPlaylistItem.Title,
                    Location = xspfPlaylistItem.Path
                });
            }

            return helperPlaylist;
        }
    }
}
