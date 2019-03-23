namespace NPlaylist.Xspf
{
    public class XspfPlaylist : BasePlaylist<XspfPlaylistItem>
    {
        private string _version = "version";
        private string _xmlns = "xmlns";

        public string Version
        {
            get => Tags.TryGetValue(_version, out var value) ? value : null;
            set => Tags[_version] = value;
        }

        public string Xmlns
        {
            get => Tags.TryGetValue(_xmlns, out var value) ? value : null;
            set => Tags[_xmlns] = value;
        }
    }
}
