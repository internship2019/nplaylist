using System;
using System.IO;
using System.Xml.Serialization;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var xspf = new XSPFPlaylist();
            xspf.PlaylistItems.Add(new XSPXEntry
            {
                title = "sgsg",
                location = "sdfsf"
            });
            xspf.PlaylistItems.Add(new XSPXEntry
            {
                title = "test",
                location = "test2"
            });

            using (var st = new StreamWriter(@"C:\Users\mpodlesnov\OneDrive - ENDAVA\Desktop\serialized.txt"))
            {
                XmlSerializer serializer =
                    new XmlSerializer(typeof(XSPFPlaylist));
                serializer.Serialize(st, xspf);
            }
        }
    }
}
