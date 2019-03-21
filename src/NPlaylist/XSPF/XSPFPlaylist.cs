using System.Collections.Generic;
using System.Xml.Serialization;

namespace NPlaylist
{
    [XmlRoot("playlist")]
    public class XSPFPlaylist : BasePlaylist<XSPXEntry>
    {
        [XmlArray("trackList")]
        [XmlArrayItem("track")]
        public override IList<IPlaylistItem> PlaylistItems { get; } = new List<IPlaylistItem>();

        public XSPFPlaylist()
        {
        }
    }
}
