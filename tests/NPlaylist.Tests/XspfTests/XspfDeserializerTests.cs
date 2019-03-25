using System;
using NPlaylist.Xspf;
using Xunit;

namespace NPlaylist.Tests
{
    public class XspfDeserializerTests
    {
        [Fact]
        public void Invalid_Format_Throws_Exception()
        {
            //Arrange 
            var xspfDeserializer = new XspfPlaylistDesrializer();

            //Assert
            Assert.Throws<Exception>(()=>xspfDeserializer.Deserialize("test string"));
        }
    }
}
