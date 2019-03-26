using System.Linq;
using NPlaylist.Wpl;
using NPlaylist.Xspf;
using Xunit;

namespace NPlaylist.Tests.XspfTests
{
    public class XspfConversionTest
    {
        [Fact]
        public void Conversion_CorrectNumberOfItemsAfterConversion_True()
        {
            var wpl = new WplPlaylist();
            wpl.Add(new WplItem("test1"));
            wpl.Add(new WplItem("test2"));
            wpl.Add(new WplItem("test3"));

            var xspf = new XspfPlaylist(wpl);

            Assert.True(wpl.GetItems().Count().Equals(xspf.GetItems().Count()));
        }

        [Fact]
        public void Conversion_ConvertedPlaylistContainsTagAuthor_True()
        {
            var wpl = new WplPlaylist
            {
                Author = "TestAuthor",
                Title = "Test Title"
            };

            var wplConvertedToXspf = new XspfPlaylist(wpl);

            Assert.True(wplConvertedToXspf.Tags.ContainsKey(TagNames.Author));
        }

        [Fact]
        public void Conversion_ConvertedAuthorEqualsToInitialPlaylitTitle_True()
        {
            var wpl = new WplPlaylist
            {
                Author = "TestAuthor",
                Title = "Test Title"
            };

            var wplConvertedToXspf = new XspfPlaylist(wpl);

            Assert.True(wplConvertedToXspf.Tags[TagNames.Author] == "TestAuthor");
        }

        [Fact]
        public void Conversion_ConvertedTitleEqualsToInitialPlaylitTitle_True()
        {
            var wpl = new WplPlaylist
            {
                Author = "TestAuthor",
                Title = "Test Title"
            };

            var wplConvertedToXspf = new XspfPlaylist(wpl);

            Assert.True(wplConvertedToXspf.Tags[TagNames.Title] == "Test Title");
        }

        [Fact]
        public void Conversion_InitialItemLocationEqualsConverted_True()
        {
            var wpl = new WplPlaylist();
            wpl.Add(new WplItem("test path"));

            var wplConvertedToXspf = new XspfPlaylist(wpl);

            var result = wplConvertedToXspf.GetItems().SingleOrDefault()?.Path;

            Assert.True(result.Equals(wpl.GetItems().SingleOrDefault()?.Path));
        }

        [Fact]
        public void Conversion_ItemTagsInConvertedPlaylistContainsTrackId_True()
        {
            var wpl = new WplPlaylist();
            wpl.Add(new WplItem("test path")
            {
                TrackId = "testID"
            });

            var wplConvertedToXspf = new XspfPlaylist(wpl);

            var result = wplConvertedToXspf.GetItems().SingleOrDefault().Tags[TagNames.TrackId];
            Assert.True(result.Equals("testID"));
        }
    }
}
