using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Core
{
    public class BasePlaylist
    {
        public Dictionary<string, string> Meta { get; set; }
        public List<BaseItem> Items { get; set; }

        public BasePlaylist()
        {
            Items = new List<BaseItem>();
            Meta = new Dictionary<string, string>();

        }
    }
}
