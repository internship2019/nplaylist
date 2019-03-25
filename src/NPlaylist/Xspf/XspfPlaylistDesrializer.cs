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
            var helperPlaylist = StringToXspfHelper(input);
            return ConvertToXspfPlaylist(helperPlaylist);
        }

        private XspfHelper.Playlist StringToXspfHelper(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(XspfHelper.Playlist));

            XspfHelper.Playlist xspfHelperObj;

            using (var reader = new StringReader(input))
            {
                try
                {
                    xspfHelperObj= xmlSerializer.Deserialize(reader) as XspfHelper.Playlist;
                    return xspfHelperObj;
                }
                catch (Exception ex)
                {
                    throw new Exception("Something wrong with xmlSerializer.Deserialize()");
                }
            }
        }

        private XspfPlaylist ConvertToXspfPlaylist(XspfHelper.Playlist playlist)
        {
            var xspfPlaylist = new XspfPlaylist();
            xspfPlaylist.Version = playlist.Version;
            
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
