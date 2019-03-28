using System.Globalization;

namespace NPlaylist.M3u
{
    public class M3uItem : BasePlaylistItem
    {
        private const decimal defaultDuration = 0;

        public M3uItem(string path, decimal duration) : base(path)
        {
            Duration = duration;
        }

        public decimal Duration
        {
            get
            {
                if (!Tags.TryGetValue(TagNames.Length, out var valueStr))
                {
                    return defaultDuration;
                }

                return decimal.TryParse(valueStr, out var decimalValue) ? decimalValue : defaultDuration;
            }

            set => Tags[TagNames.Length] = value.ToString(CultureInfo.InvariantCulture);
        }

        public string Title
        {
            get
            {
                var title = Tags.TryGetValue(TagNames.Title, out var value) ? value : null;
                return title?.Trim();
            }

            set => Tags[TagNames.Title] = value;
        }
    }
}
