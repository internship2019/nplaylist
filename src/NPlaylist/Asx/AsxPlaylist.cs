using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Asx
{
    public class AsxPlaylist : BasePlaylist<AsxItem>
    {
        public AsxPlaylist()
        {
        }

        public AsxPlaylist(IPlaylist playlist)
        {
            foreach (var playlistTag in playlist.Tags)
            {
                Tags[playlistTag.Key] = playlistTag.Value;
            }

            foreach (var playlistItem in playlist.GetItems())
            {
                Add(new AsxItem(playlistItem));
            }
        }

        public string Title
        {
            get => Tags.TryGetValue(TagNames.Title, out var value) ? value : null;
            set => Tags[TagNames.Title] = value;
        }

        public string Version
        {
            get => Tags.TryGetValue(TagNames.Version, out var value) ? value : null;
            set => Tags[TagNames.Version] = value;
        }
    }
}
