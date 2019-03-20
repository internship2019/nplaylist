using System.IO;

namespace NPlaylist.Core
{
    public interface IPlaylistSerializer
    {
        Playlist Deserialize(TextReader reader);
        string Serialize(Playlist playlist);
    }
}
