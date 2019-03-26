using System;
using System.IO;
using NPlaylist.Wpl;
using NPlaylist.Xspf;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WplPlaylist wpl;
            using (var streamReader = new StreamReader(@"C:\Users\mpodlesnov\OneDrive - ENDAVA\Desktop\Serialized.txt"))
            {
                var wplDeserializer = new WplDeserializer();
                wpl = wplDeserializer.Deserialize(streamReader.ReadToEnd());
            }

            //conversion
            var xspf = new XspfPlaylist(wpl);
            using (var streamWriter= new StreamWriter(@"C:\Users\mpodlesnov\OneDrive - ENDAVA\Desktop\Serialized.txt"))
            {
              var xspfSerializer = new XspfSerializer();
              streamWriter.Write(xspfSerializer.Serialize(xspf));
            }

        }
    }
}
