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

            var playlist = obj.Deserialize(new FileStream(@"C:\list.m3u",
                FileMode.Open));
            
            using (var stream = new FileStream(@"C:\Serialized.txt",
                FileMode.OpenOrCreate))
            {
       
                obj.Serialize(playlist,stream);
            }
           
            Console.ReadLine();
        }
    }
}
