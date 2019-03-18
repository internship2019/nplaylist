using System;
using System.IO;
using System.Xml;

namespace NPlaylist.Models
{
    public class XSPFSerializator:ISerializator<XSPFPlaylist>
    {
        public void Serialize(XSPFPlaylist playlist, Stream stream)
        {
            using (var streamWriter = XmlWriter.Create(stream))
            {
                
            }
        }

        public XSPFPlaylist Deserialize(Stream stream, ArgumentNullException argumentNullException)
        {
            throw new System.NotImplementedException();
        }
    }
}
