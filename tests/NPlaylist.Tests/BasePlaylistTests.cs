using System;
using System.Linq;
using NSubstitute;
using Xunit;

namespace NPlaylist.Tests
{
    public class BasePlaylistTests
    {
        [Fact]
        public void Add_Adds_ExpectedItem()
        {
            // Arrange 
            var dummyItem = Substitute.For<IPlaylistItem>();
            var basePlaylist = Substitute.For<BasePlaylist<IPlaylistItem>>();

            // Act 
            basePlaylist.Add(dummyItem);

            // Assert 
            Assert.Contains(dummyItem, basePlaylist.GetItems());
        }

        [Fact]
        public void Remove_Removes_ExpectedItem()
        {
            // Arrange 
            var dummyItem = Substitute.For<IPlaylistItem>();
            var basePlaylist = Substitute.For<BasePlaylist<IPlaylistItem>>();
            basePlaylist.Add(dummyItem);

            // Act 
            basePlaylist.Remove(dummyItem);

            // Assert 
            Assert.DoesNotContain(dummyItem, basePlaylist.GetItems());
        }
    }
}
