using System;
using System.IO;

namespace NPlaylist.Core
{
    public static class NPlaylistSerializer
    {
        public static Playlist Deserialize(TextReader reader)
        {
            return new Playlist();
        }
        public static string Serialize(Playlist playlist)
        {
            return String.Empty;
        }
    }
}
