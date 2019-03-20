using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Core
{
    public class Playlist
    {
        public IDictionary<string, string> Tags { get; set; }
        public IList<PlaylistItem> Items { get; set; }

        public Playlist()
        {
            Items = new List<PlaylistItem>();
            Tags = new Dictionary<string, string>();
        }
    }
}
