using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Asx
{
    public class AsxPlaylist : BasePlaylist<AsxItem>
    {
        private const string _playlistKeyTitle = "title";
        private const string _playlistKeyVersion = "version";

        public string Title
        {
            get => Tags.TryGetValue(_playlistKeyTitle, out var value) ? value : null;
            set => Tags[_playlistKeyTitle] = value;
        }

        public string Version
        {
            get => Tags.TryGetValue(_playlistKeyVersion, out var value) ? value : null;
            set => Tags[_playlistKeyVersion] = value;
        }
    }
}
