using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.WPL
{
    public class WplPlaylist : BasePlaylist<WplPlaylistItem>, IPlaylistItem
    {
        public WplPlaylist(IPlaylist playlist)
        {
            //TODO: parse playlist tgs
            //TODO: add playlist items
        }
    }
}
