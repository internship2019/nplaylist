using System.Collections.Generic;

namespace NPlaylist.M3u
{
    public class M3uPlaylist : BasePlaylist<M3uItem>
    {
        public M3uPlaylist()
        {
        }

        public M3uPlaylist(IPlaylist playlist) : base(playlist)
        {
        }

        protected override M3uItem CreateItem(IPlaylistItem item)
        {
            return new M3uItem(item);
        }

        public void AddRange(IEnumerable<M3uItem> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
