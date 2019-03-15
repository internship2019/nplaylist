namespace NPlaylist.Models
{
    public class XSPFPlaylist:BasePlaylist<XSPFEntry>
    {
        public int Version { get; set; }
        public string Xmlns { get; set; }
    }
}
