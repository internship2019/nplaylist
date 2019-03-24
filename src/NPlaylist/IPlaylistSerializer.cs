namespace NPlaylist
{
    public interface IPlaylistSerializer<T> where T : IPlaylist
    {
        string Serialize(T playlist);
    }
}
