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
            Tags = new Dictionary<string, string>(playlist.Tags);
            Version = Tags.TryGetValue(TagNames.Version, out var value) ? value : null;

            foreach (var item in playlist.GetItems())
            {
                Add(new XspfPlaylistItem(item));
            }
        }
    }
}
