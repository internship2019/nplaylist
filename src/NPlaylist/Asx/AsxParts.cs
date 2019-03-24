using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NPlaylist.Asx
{
    public static class AsxParts
    {
        [XmlRoot(ElementName = "ref")]
        public class Ref
        {
            [XmlAttribute(AttributeName = "href")]
            public string Href { get; set; }
        }

        [XmlRoot(ElementName = "param")]
        public class ParamItem
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "entry")]
        public class Entry
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlElement(ElementName = "ref")]
            public Ref Ref { get; set; }
            [XmlElement(ElementName = "param")]
            public List<ParamItem> Param { get; set; }
            [XmlElement(ElementName = "author")]
            public string Author { get; set; }
            [XmlElement(ElementName = "copyright")]
            public string Copyright { get; set; }
        }

        [XmlRoot(ElementName = "asx")]
        public class Asx
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlElement(ElementName = "entry")]
            public List<Entry> Entry { get; set; }
            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }
        }
    }
}
