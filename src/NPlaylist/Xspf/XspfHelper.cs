using System.Collections.Generic;
using System.Xml.Serialization;

namespace NPlaylist.Xspf
{
    public static class XspfHelper
    {
        [XmlRoot(ElementName = "track", Namespace = "http://xspf.org/ns/0/")]
        public class Track
        {
            [XmlElement(ElementName = "title", Namespace = "http://xspf.org/ns/0/")]
            public string Title { get; set; }

            [XmlElement(ElementName = "location", Namespace = "http://xspf.org/ns/0/")]
            public string Location { get; set; }
        }

        [XmlRoot(ElementName = "trackList", Namespace = "http://xspf.org/ns/0/")]
        public class TrackList
        {
            [XmlElement(ElementName = "track", Namespace = "http://xspf.org/ns/0/")]
            public List<Track> Track { get; set; }
        }

        [XmlRoot(ElementName = "playlist", Namespace = "http://xspf.org/ns/0/")]
        public class Playlist
        {
            [XmlElement(ElementName = "trackList", Namespace = "http://xspf.org/ns/0/")]
            public TrackList TrackList { get; set; }

            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }
        }
    }
}
