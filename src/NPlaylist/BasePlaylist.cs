using System.Collections.Generic;
using System.Linq;

namespace NPlaylist
{
    public abstract class BasePlaylist<T> : IPlaylist<T>
        where T : IPlaylistItem
    {
        private readonly List<T> _items;

        protected BasePlaylist()
        {
            Tags = new Dictionary<string, string>();
            _items = new List<T>();
        }

        public IDictionary<string, string> Tags { get; }

        public IEnumerable<T> Items => _items;

        public IEnumerable<IPlaylistItem> GetItems()
        {
            return _items.Cast<IPlaylistItem>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}
