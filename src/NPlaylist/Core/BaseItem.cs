using System.Collections.Generic;

namespace NPlaylist.Core
{
    public class BaseItem
    {
        public Dictionary<string,string> ItemData { get; set; }
        
        public BaseItem()
        {
            ItemData = new Dictionary<string, string>();
        }
    }
}
