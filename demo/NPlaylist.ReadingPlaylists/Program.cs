using System;
using System.IO;
using AutoMapper;
using NPlaylist.Models;
using NPlaylist.Extensions;

namespace NPlaylist.ReadingPlaylists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var obj = new M3USerializator();

            var stream = new FileStream(@"C:\list.m3u", FileMode.Open);

            var playlist = obj.Deserialize(stream);
            
            stream.Close();
            Console.WriteLine("Imported {0} entries\n",playlist.Entries.Count);
            
            Console.WriteLine(obj.Serialize(playlist));


            // Auto-Mapping test
            var destination = Mapping.Mapper.Map<XSPFPlaylist>(playlist);

            Console.WriteLine("Try hard: " + destination.Version + "\nNumbers: " + destination.Entries.Count);

            Console.ReadLine();
        }
    }
}
