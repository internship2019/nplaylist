using System.Collections.Generic;

namespace NPlaylist
{
    public interface IPlaylist
    {
        IDictionary<string, string> Tags { get; }
        IEnumerable<IPlaylistItem> GetItems();
    }

    public interface IPlaylist<T> : IPlaylist
        where T : IPlaylistItem
    {
        IEnumerable<T> Items { get; }

        void Add(T item);

        void Remove(T item);
    }
}
