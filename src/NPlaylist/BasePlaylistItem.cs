using System.Collections.Generic;

namespace NPlaylist
{
    public abstract class BasePlaylistItem : IPlaylistItem
    {
        private  string _path = "path";
        public IDictionary<string, string> Tags { get; }

        public string Path
        {
            get => Tags.TryGetValue(_path, out var value) ? value : null;
            set => Tags[_path] = value;
        }

        protected BasePlaylistItem()
        {
            Tags = new Dictionary<string, string>();
        }
    }
}
