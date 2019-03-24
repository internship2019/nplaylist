using System;
using System.IO;
using NPlaylist.Asx;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var f = new AsxDeserializer();
            var ser = new AsxSerializer();
            using (var sr = new StreamReader(@"C:\Users\Admin\Desktop\test.txt"))
            {
                var str = sr.ReadToEnd();
                var r = f.Deserialize(str);

                Console.WriteLine(ser.Serialize(r));
            }
            Console.ReadKey();
        }
    }
}
