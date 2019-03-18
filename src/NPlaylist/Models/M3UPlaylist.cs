using System.Collections.Generic;
using NPlaylist.Models;

namespace NPlaylist
{
    public class M3UPlaylist:BasePlaylist<M3UEntry>
    {
        public bool IsExtended { get; set; }

        public M3UPlaylist()
        {
            IsExtended = true;
        }
    }
}
