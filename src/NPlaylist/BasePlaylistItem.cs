using System.Collections.Generic;

namespace NPlaylist
{
    public abstract class BasePlaylistItem : IPlaylistItem
    {
        public IDictionary<string, string> Tags { get; }

        public string Path
        {
            get => Tags.TryGetValue(KeyNames.Path, out var value) ? value : null;
            set => Tags[KeyNames.Path] = value;
        }

        protected BasePlaylistItem()
        {
            Tags = new Dictionary<string, string>();
        }
    }
}
