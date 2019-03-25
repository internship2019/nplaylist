namespace NPlaylist.Xspf
{
    public class XspfPlaylist : BasePlaylist<XspfPlaylistItem>
    {
        private const string _version = "version";

        public string Version
        {
            get => Tags.TryGetValue(_version, out var value) ? value : null;
            set => Tags[_version] = value;
        }
    }
}
