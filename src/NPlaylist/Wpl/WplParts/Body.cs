using System.Xml.Serialization;

namespace NPlaylist.Wpl.WplParts
{
    [XmlRoot(ElementName = "body")]
    public class Body
    {
        [XmlElement(ElementName = "seq")]
        public Sequence Sequence { get; set; }
    }
}
