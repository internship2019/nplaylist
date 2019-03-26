using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using NSubstitute;
using NPlaylist.Asx;

namespace NPlaylist.Tests.Asx
{
    public class AsxConversionTests
    {
        [Fact]
        public void Conversion_CorrespondWithTheSameAmountOfItems_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var item = Substitute.For<IPlaylistItem>();
            playlist.GetItems().Returns(new[] { item });

            var asx = new AsxPlaylist(playlist);
            Assert.True(playlist.GetItems().Count() == asx.GetItems().Count());
        }

        [Fact]
        public void Conversion_ConvertedPlaylistContainsTitleTag_True()
        {
            var playlist = Substitute.For<IPlaylist>();
            var dictionary = new Dictionary<string, string>
            {
                { TagNames.Author, "Foo" }
            };
            playlist.Tags.Returns(dictionary);

            var asx = new AsxPlaylist(playlist);
            Assert.True(asx.Tags.ContainsKey(TagNames.Author));
        }

        [Fact]
        public void Conversion_ConvertedPlaylistContainsInitialTitle_Foo()
        {
            var playlist = Substitute.For<IPlaylist>();
            var dictionary = new Dictionary<string, string>
            {
                { TagNames.Author, "Foo" }
            };
            playlist.Tags.Returns(dictionary);

            var asx = new AsxPlaylist(playlist);
            Assert.True(asx.Tags[TagNames.Author] == "Foo");
        }

        [Fact]
        public void Conversion_ConvertedPlaylistItemContainsSamePath_Foo()
        {
            var playlist = Substitute.For<IPlaylist>();
            var item = Substitute.For<IPlaylistItem>();
            item.Path.Returns("Foo");
            playlist.GetItems().Returns(new[] { item });

            var asx = new AsxPlaylist(playlist);
            Assert.True(asx.GetItems().First().Path == "Foo");
        }

        [Fact]
        public void Conversion_ConvertedPlaylistItemContainsParam_FooToBar()
        {
            var playlist = Substitute.For<IPlaylist>();
            var item = Substitute.For<IPlaylistItem>();
            var dictionary = new Dictionary<string, string>
            {
                { "Foo", "Bar" }
            };
            item.Tags.Returns(dictionary);
            playlist.GetItems().Returns(new [] {item});

            var asx = new AsxPlaylist(playlist);
            Assert.True(asx.GetItems().First().Tags["Foo"] == "Bar");
        }
    }
}
