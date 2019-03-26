using System.Xml.Serialization;

namespace NPlaylist.Wpl.WplParts
{
    [XmlRoot(ElementName = "smil")]
    public class RawPlaylist
    {
        [XmlElement(ElementName = "head")]
        public Head Head { get; set; }

        [XmlElement(ElementName = "body")]
        public Body Body { get; set; }
    }
}
