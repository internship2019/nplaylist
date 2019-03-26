using System;
using System.Drawing.Design;
using NPlaylist.Xspf;
using Xunit;

namespace NPlaylist.Tests.XspfTests
{
    public class XspfSerializerTests
    {
        [Fact]
        public void Serialize_SerizlizerReturnsNotEmptyString_True()
        {
            var xspfSerializer = new XspfPlaylistSerializer();
            var xspfPlaylist = new XspfPlaylist
            {
                Version = "1"
            };
            var result = xspfSerializer.Serialize(xspfPlaylist);

            Assert.True(result != String.Empty);
        }

        [Fact]
        public void Serialize_NullInputAsParameter_ArgumentNullExceptionThrown()
        {
            var xspfSerializer = new XspfPlaylistSerializer();

            Assert.Throws<ArgumentNullException>(() => xspfSerializer.Serialize(null));
        }

        [Fact]
        public void Serialize__SerializedPlaylistContainsTracklist_True()
        {
            var xspfPlaylist = new XspfPlaylist();
            var xspfSerializer = new XspfPlaylistSerializer();
            var actualResult = xspfSerializer.Serialize(xspfPlaylist);

            Assert.Contains("<trackList />", actualResult);
        }

        [Fact]
        public void Serialize__SerializedPlaylistContainsItemTitle_True()
        {
            var xspfPlaylist = new XspfPlaylist();
            xspfPlaylist.Add(new XspfPlaylistItem("test_location")
            {
                Title = "test_element"
            });
            var xspfSerializer = new XspfPlaylistSerializer();
            var actualResult = xspfSerializer.Serialize(xspfPlaylist);

            Assert.Contains("<title>test_element</title>", actualResult);
        }
    }
}
