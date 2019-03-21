namespace NPlaylist
{
    public interface IPlaylistDeserializer<T> where T : IPlaylist
    {
        T Deserialize(string input);
    }
}
