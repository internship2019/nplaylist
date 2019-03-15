using System;
using System.IO;

namespace NPlaylist.Models
{
    public class M3USerializator : ISerializator<M3UPlaylist>
    {
        public void Serialize(M3UPlaylist playlist, Stream stream)
        {
            using (var sw = new StreamWriter(stream))
            {
                foreach (var entry in playlist.Entries)
                {
                    sw.WriteLine(entry.Path);
                }
            }
            
        }

        public M3UPlaylist Deserialize(Stream stream)
        {
            var playlist = new M3UPlaylist();
     
            StreamReader sr = new StreamReader(stream);
            

            while(!sr.EndOfStream)
            {
                
                    playlist.Entries.Add(new M3UEntry
                    {
                        Path = sr.ReadLine()
                    });
                
            }

            return playlist;
        }
    }
}
