using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using NPlaylist.Asx;
using NSubstitute;
using Xunit;

namespace NPlaylist.Tests.Asx
{
    public class AsxDeserializerTests
    {
        [Fact]
        public void Deserialize_NullInput_ThrowsException()
        {
            var deserializer = new AsxDeserializer();

            Assert.Throws<ArgumentNullException>(() => deserializer.Deserialize(null));
        }

        [Fact]
        public void Deserialize_EmptyInput_ThrowsException()
        {
            var deserializer = new AsxDeserializer();

            Assert.Throws<ArgumentNullException>(() => deserializer.Deserialize(string.Empty));
        }

        [Fact]
        public void Deserialize_IncorrectFormat_ThrowsException()
        {
            var deserializer = new AsxDeserializer();

            Assert.Throws<FormatException>(() => deserializer.Deserialize("Foo"));
        }

        [Fact]
        public void Deserialize_TagIsParrsedAsExpected()
        {
            string asxWithMeta_FooToBar =
            @"
                <asx />
            ";
            var deserializer = new AsxDeserializer();
            var playlist = deserializer.Deserialize(asxWithMeta_FooToBar);
            
            Assert.True(!playlist.Items.Any());
        }

        [Fact]
        public void Deserialize_TitleIsParrsedAsExpected()
        {
            string asxWithTitle_Foo =
            @"
                <asx>
                  <title>Foo</title>
                </asx>
            ";
            var deserializer = new AsxDeserializer();
            var playlist = deserializer.Deserialize(asxWithTitle_Foo);
            
            Assert.True(playlist.Title == "Foo");
        }

        [Fact]
        public void Deserialize_VersionIsParrsedAsExpected()
        {
            string asxWithVersion_Foo =
            @"
                <asx version=""Foo"">
                </asx>
            ";
            var deserializer = new AsxDeserializer();
            var playlist = deserializer.Deserialize(asxWithVersion_Foo);

            Assert.True(playlist.Version == "Foo");
        }

        [Fact]
        public void Deserialize_RefIsParrsedAsExpected()
        {
            string asxWithRef_Foo =
            @"
                <asx>
                  <entry>
                    <ref href=""Foo"" />
                  </entry>
                </asx>
            ";
            var deserializer = new AsxDeserializer();
            var playlist = deserializer.Deserialize(asxWithRef_Foo);

            var asxItem = playlist.Items.First();
            Assert.True(playlist.Items.Count() == 1 && asxItem.Path == "Foo");
        }
    }
}
