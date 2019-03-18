using System;
using System.IO;
using System.Text;

namespace NPlaylist.Models
{
    public class M3USerializator : ISerializator<M3UPlaylist>
    {
        private const string EXTM3U = "#EXTM3U";
        private const string EXTINF = "#EXTINF";

        public string Serialize(M3UPlaylist playlist)
        {
            if (playlist == null)
            {
                throw new NullReferenceException("Empty playlist");
            }

            var sb = new StringBuilder();

            if (playlist.IsExtended)
            {
                sb.AppendLine(EXTM3U);
            }

            foreach (var entry in playlist.Entries)
            {
                if (playlist.IsExtended)
                {
                    sb.AppendLine().Append(EXTINF+":").Append((int)entry.Duration.TotalSeconds).Append(",");
                    if (!String.IsNullOrEmpty(entry.Artist))
                    {
                        sb.Append(entry.Artist).Append("-");
                    }

                    if (!String.IsNullOrEmpty(entry.Title))
                    {
                        sb.Append(entry.Title);
                    }

                    sb.AppendLine();
                }
                sb.AppendLine(entry.Path);
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString(); 
        }

        public M3UPlaylist Deserialize(Stream stream)
        {

            var playlist = new M3UPlaylist();

            using (var sr = new StreamReader(stream))
            {
                string line;

                int duration = 0;
                string artist = "";
                string title = "";
                string path = "";

                if (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    playlist.IsExtended = line.Trim() == EXTM3U;
                    if (!playlist.IsExtended && !string.IsNullOrEmpty(line))
                    {
                        playlist.Entries.Add(new M3UEntry()
                        {
                            Artist = artist,
                            Duration = TimeSpan.FromSeconds(duration),
                            Path = line,
                            Title = title
                        });
                    }
                }

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.StartsWith(EXTINF) && playlist.IsExtended == true)
                        {
                            var info = line.Substring(8).Split(new char[] { ',', '-' });
                            if (info != null)
                            {
                                int.TryParse(info[0], out duration);
                                artist = info[1];
                                title = info[2];
                                path = sr.ReadLine();
                            }
                        }
                        else
                        {
                            duration = 0;
                            artist = "";
                            title = "";
                            path = line;
                        }

                        playlist.Entries.Add(new M3UEntry()
                        {
                            Artist = artist,
                            Duration = TimeSpan.FromSeconds(duration),
                            Path = path,
                            Title = title
                        });
                    }
                }
            }

            return playlist;
        }
    }
}
