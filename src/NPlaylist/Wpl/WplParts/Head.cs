using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace NPlaylist.Wpl.WplParts
{
    [XmlRoot(ElementName = "head")]
    public class Head
    {
        [XmlElement(ElementName = "meta")]
        public List<Meta> Meta { get; set; }

        [XmlElement(ElementName = "author")]
        public string Author { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
    }
}
