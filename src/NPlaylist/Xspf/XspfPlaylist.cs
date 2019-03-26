using System.Collections.Generic;
using System.Linq;

namespace NPlaylist.Xspf
{
    public class XspfPlaylist : BasePlaylist<XspfPlaylistItem>
    {
        public string Version
        {
            get => Tags.TryGetValue(TagNames.Version, out var value) ? value : null;
            set => Tags[TagNames.Version] = value;
        }

        public XspfPlaylist()
        {
        }

        public XspfPlaylist(IPlaylist playlist)
        {
            foreach (var playlistTag in playlist.Tags)
            {
                Tags[playlistTag.Key] = playlistTag.Value;
            }

            foreach (var item in playlist.GetItems())
            {
                Add(new XspfPlaylistItem(item));
            }
        }
    }
}
