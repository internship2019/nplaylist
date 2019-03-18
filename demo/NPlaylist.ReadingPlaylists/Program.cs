using System;
using System.IO;
using NPlaylist.Models;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var obj = new M3USerializator();

            var playlist = obj.Deserialize(new FileStream(@"C:\Users\Admin\Desktop\test.txt",
                FileMode.Open));

            Console.WriteLine("Imported {0} entries\n",playlist.Entries.Count);
            
            Console.WriteLine(obj.Serialize(playlist));
           
            Console.ReadLine();
        }
    }
}
