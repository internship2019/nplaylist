using System.Collections.Generic;

namespace NPlaylist
{
    public interface IPlaylist
    {
        IDictionary<string, string> Tags { get; }
        IList<IPlaylistItem> PlaylistItems { get; }
    }

    public interface IPlaylist<T> : IPlaylist where T : IPlaylistItem
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
