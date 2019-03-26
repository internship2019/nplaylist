using System.Collections.Generic;
using System.Linq;
using NPlaylist.Wpl;
using NPlaylist.Xspf;
using NSubstitute;
using Xunit;

namespace NPlaylist.Tests.XspfTests
{
    public class XspfConversionTest
    {
        [Fact]
        public void Conversion_CorrectNumberOfItemsAfterConversion_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var item = Substitute.For<IPlaylistItem>();
            playlist.GetItems().Returns(new[] {item});

            var xspf = new XspfPlaylist(playlist);

            Assert.True(playlist.GetItems().Count()==xspf.GetItems().Count());
        }

        [Fact]
        public void Conversion_ConvertedPlaylistContainsTagAuthor_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var dictionary = new Dictionary<string,string>();
            dictionary.Add(TagNames.Author, "Value");
            playlist.Tags.Returns(dictionary);
         
            var xspf = new XspfPlaylist(playlist);

            Assert.True(xspf.Tags.ContainsKey(TagNames.Author));
        }

        [Fact]
        public void Conversion_ConvertedAuthorEqualsToInitialPlaylitTitle_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var dictionary = new Dictionary<string,string>();
            dictionary.Add(TagNames.Author,"TestAuthor");
            playlist.Tags.Returns(dictionary);
            var xspf = new XspfPlaylist(playlist);

            Assert.True(xspf.Tags[TagNames.Author] == "TestAuthor");
        }

        [Fact]
        public void Conversion_ConvertedTitleEqualsToInitialPlaylitTitle_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(TagNames.Title, "Test Title");
            playlist.Tags.Returns(dictionary);
            var xspf = new XspfPlaylist(playlist);

            Assert.True(xspf.Tags[TagNames.Title] == "Test Title");
        }

        [Fact]
        public void Conversion_InitialItemLocationEqualsConverted_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var item = Substitute.For<IPlaylistItem>();
            item.Path.Returns("test path");
            playlist.GetItems().Returns(new[] {item});

            var xspf = new XspfPlaylist(playlist);
            var receivedItem = xspf.GetItems().First();
            var a = receivedItem.Path;
            var xspfItemPath = receivedItem.Path;
            
            Assert.True(xspfItemPath.Equals(playlist.GetItems().First().Path));
        }

        [Fact]
        public void Conversion_ItemTagsInConvertedPlaylistContainsTrackId_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var item = Substitute.For<IPlaylistItem>();
            var dictionary = new Dictionary<string,string>();
            dictionary.Add(TagNames.TrackId,"testID");
            item.Tags.Returns(dictionary);
            playlist.GetItems().Returns(new[] { item });

            var xspf = new XspfPlaylist(playlist);

            var result = xspf.GetItems().First().Tags[TagNames.TrackId];
            Assert.True(result.Equals("testID"));
        }
    }
}
