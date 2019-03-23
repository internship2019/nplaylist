namespace NPlaylist.Xspf
{
    public class XspfPlaylistItem : BasePlaylistItem
    {
        private string _title = "title";

        public string Title
        {
            get => Tags.TryGetValue(_title, out var value) ? value : null;
            set => Tags[_title] = value;
        }
    }
}
