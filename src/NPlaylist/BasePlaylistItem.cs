using System.Collections.Generic;

namespace NPlaylist
{
    public abstract class BasePlaylistItem : IPlaylistItem
    {
        private const string _pathKeyName = "path";

        public IDictionary<string, string> Tags { get; }

        public string Path
        {
            get => Tags.TryGetValue(_pathKeyName, out var value) ? value : null;
            set => Tags[_pathKeyName] = value;
        }

        protected BasePlaylistItem()
        {
            Tags = new Dictionary<string, string>();
        }
    }
}
