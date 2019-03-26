namespace NPlaylist.Xspf
{
    public class XspfPlaylist : BasePlaylist<XspfPlaylistItem>
    {
        public string Version
        {
            get => Tags.TryGetValue(TagNames.Version, out var value) ? value : null;
            set => Tags[TagNames.Version] = value;
        }
    }
}
