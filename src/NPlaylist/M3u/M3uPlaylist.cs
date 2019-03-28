namespace NPlaylist.M3u
{
    public class M3uPlaylist : BasePlaylist<M3uItem>
    {
        protected override M3uItem CreateItem(IPlaylistItem item)
        {
            return new M3uItem(item);
        }
    }
}
