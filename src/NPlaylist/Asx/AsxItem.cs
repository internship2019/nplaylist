using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Asx
{
    public class AsxItem : BasePlaylistItem
    {
        public AsxItem(string path) : base(path)
        {
        }

        public AsxItem(IPlaylistItem item) : base(item)
        {
        }
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

        public string Copyright
        {
            get => Tags.TryGetValue(TagNames.Copyright, out var value) ? value : null;
            set => Tags[TagNames.Copyright] = value;
        }
    }
}
