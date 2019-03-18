using System;
using System.IO;

namespace NPlaylist.Models
{
    public class M3USerializator : ISerializator<M3UPlaylist>
    {
        public void Serialize(M3UPlaylist playlist, Stream stream)
        {
            if (playlist == null)
                throw new ArgumentNullException("Empty playlist");

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
            if (!File.Exists(stream.ToString()))
            {
                return null;
            }

            var playlist = new M3UPlaylist();
     
            var sr = new StreamReader(stream);
            int lineCount = 0;
            string line;

            while((line = sr.ReadLine()) != null)
            {
                if (lineCount == 0 && line != "#EXTM3U")
                {
                    playlist.IsExtended = false;
                }

                if (!playlist.IsExtended)
                {
                    if (line.StartsWith("#"))
                        throw new ArgumentException("Wrong path format");
                    playlist.Entries.Add(new M3UEntry()
                        { Path = line });
                }
                else
                {
                    if (line.StartsWith("#EXTINF:"))
                    {
                        var split = line.Substring(8, line.Length - 8).Split(new[] { ',', '-' });
                        if (split.Length != 3)
                            throw new ArgumentException("Invalid track information");

                        if (!int.TryParse(split[0], out var seconds))
                            throw new ArgumentException("Invalid track duration");

                        var artist = split[1];
                        var title = split[2];

                        var testingPath = sr.ReadLine();
                        if (testingPath != null && testingPath.StartsWith("#"))
                            throw new ArgumentException("Wrong path format");

                        playlist.Entries.Add(new M3UEntry()
                            { Name = title, Artist = artist, Length = seconds, Path = testingPath });
                    }
                }
                lineCount++;
            }

            return playlist;
        }
    }
}
