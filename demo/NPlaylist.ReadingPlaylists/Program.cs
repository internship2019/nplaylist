using System;
using System.IO;
using NPlaylist.Xspf;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deserializer = new XspfPlaylistDesrializer();

            string s;
            using (var stRe = new StreamReader(@"C:\Users\Slick\Desktop\VBA.txt"))
            {
                 s = stRe.ReadToEnd();
            }

            var xspf = deserializer.Deserialize(s);

            var  serializer = new XspfPlaylistSerializer();
            using (var stRe = new StreamWriter(@"C:\Users\Slick\Desktop\VBA1.txt"))
            {
                stRe.Write(serializer.Serialize(xspf));
            }

            var d = 0;
        }
    }
}
