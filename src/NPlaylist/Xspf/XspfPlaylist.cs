namespace NPlaylist.Xspf
{
    public class XspfPlaylist : BasePlaylist<XspfPlaylistItem>
    {
        public string Version
        {
            get => Tags.TryGetValue(KeyNames.Version, out var value) ? value : null;
            set => Tags[KeyNames.Version] = value;
        }
    }
}
