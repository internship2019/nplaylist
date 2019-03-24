using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaylist.Asx
{
    public class AsxItem : BasePlaylistItem
    {
        private const string _itemKeyTitle = "title";
        private const string _itemKeyAuthor = "author";
        private const string _itemKeyCopyright = "copyright";

        public string Title
        {
            get => Tags.TryGetValue(_itemKeyTitle, out var value) ? value : null;
            set => Tags[_itemKeyTitle] = value;
        }

        public string Author
        {
            get => Tags.TryGetValue(_itemKeyAuthor, out var value) ? value : null;
            set => Tags[_itemKeyAuthor] = value;
        }

        public string Copyright
        {
            get => Tags.TryGetValue(_itemKeyCopyright, out var value) ? value : null;
            set => Tags[_itemKeyCopyright] = value;
        }
    }
}
