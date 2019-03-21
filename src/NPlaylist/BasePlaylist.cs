using System.Collections.Generic;

namespace NPlaylist
{
    public abstract class BasePlaylist<T> : IPlaylist<T> where T : IPlaylistItem
    {
        public IDictionary<string, string> Tags { get; }
        public virtual IList<IPlaylistItem> PlaylistItems { get; }

        protected BasePlaylist()
        {
            Tags = new Dictionary<string, string>();
            PlaylistItems = new List<IPlaylistItem>();
        }

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
