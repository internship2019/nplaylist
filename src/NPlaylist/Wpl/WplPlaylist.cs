using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Wpl
{
    public class WplPlaylist : BasePlaylist<WplItem>
    {
        public string Title
        {
            get => Tags.TryGetValue(TagNames.Title, out var value) ? value : null;
            set => Tags[TagNames.Title] = value;
        }

        public string Author
        {
            get => Tags.TryGetValue(TagNames.Author, out var value) ? value : null;
            set => Tags[TagNames.Author] = value;
        }

        public WplPlaylist()
        {
        }

        public WplPlaylist(IPlaylist playlist) : base(playlist)
        {
        }

        protected override WplItem CreateItem(IPlaylistItem item)
        {
            return new WplItem(item);
        }
    }
}
