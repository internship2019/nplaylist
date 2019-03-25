using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPlaylist.Xspf;
using Xunit;

namespace NPlaylist.Tests
{
    public class XspfSerializerTests
    {
        [Fact]
        public void Serializer_Returns_not_empty_String()
        {
            //Arrange
            var xspfSerializer = new XspfPlaylistSerializer();
            var xspfPlaylist = new XspfPlaylist
            {
                Version = "1"
            };

            //Act
            var result = xspfSerializer.Serialize(xspfPlaylist);

            //Assert
            Assert.True(result != String.Empty);
        }
    }
}
