namespace NPlaylist.Xspf
{
    public class XspfPlaylistItem : BasePlaylistItem
    {
        public string Title
        {
            get => Tags.TryGetValue(KeyNames.Title, out var value) ? value : null;
            set => Tags[KeyNames.Title] = value;
        }
    }
}
