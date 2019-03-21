using System.Collections.Generic;

namespace NPlaylist
{
    public abstract class BasePlaylistItem : IPlaylistItem
    {
        public IDictionary<string, string> Tags { get; }
        public string Path { get; }

        protected BasePlaylistItem()
        {
            Tags = new Dictionary<string, string>();
        }
    }
}
