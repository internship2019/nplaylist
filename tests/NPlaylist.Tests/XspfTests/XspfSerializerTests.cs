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
    }
}
