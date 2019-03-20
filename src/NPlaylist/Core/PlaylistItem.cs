using System.Collections.Generic;

namespace NPlaylist.Core
{
    public class PlaylistItem
    {
        public IDictionary<string,string> Tags { get; set; }
        
        public PlaylistItem()
        {
            Tags = new Dictionary<string, string>();
        }
    }
}
