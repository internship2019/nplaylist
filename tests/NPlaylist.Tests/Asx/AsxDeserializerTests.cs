using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPlaylist.Asx;
using NSubstitute;
using Xunit;

namespace NPlaylist.Tests.Asx
{
    public class AsxDeserializerTests
    {
        [Fact]
        public void Deserialize_IncorrectFormat_ThrowsException()
        {
            // Arrange
            var deserializer = new AsxDeserializer();

            // Act && Assert
            Assert.Throws<InvalidAsxFormatException>(() => deserializer.Deserialize("Foo"));
        }

        [Fact]
        public void Deserialize_TagIsParrsedAsExpected()
        {
            // Arrange
            var deserializer = new AsxDeserializer();

            // Act
            var playlist = deserializer.Deserialize(asxWithMeta_FooToBar);

            // Assert
            Assert.True(playlist.Items.Count() == 1);
            var asxItem = playlist.Items.First();

            Assert.True(asxItem.Tags["Foo"] == "Bar");
            Assert.True(asxItem.Path == null);
        }

        [Fact]
        public void Deserialize_TitleIsParrsedAsExpected()
        {
            // Arrange
            var deserializer = new AsxDeserializer();

            // Act
            var playlist = deserializer.Deserialize(asxWithTitle_Foo);

            // Assert
            Assert.True(playlist.Title == "Foo");
        }

        [Fact]
        public void Deserialize_VersionIsParrsedAsExpected()
        {
            // Arrange
            var deserializer = new AsxDeserializer();

            // Act
            var playlist = deserializer.Deserialize(asxWithVersion_Foo);

            // Assert
            Assert.True(playlist.Version == "Foo");
        }

        [Fact]
        public void Deserialize_RefIsParrsedAsExpected()
        {
            // Arrange
            var deserializer = new AsxDeserializer();

            // Act
            var playlist = deserializer.Deserialize(asxWithRef_Foo);

            // Assert
            Assert.True(playlist.Items.Count() == 1);
            var asxItem = playlist.Items.First();

            Assert.True(asxItem.Path == "Foo");
        }

        #region Xml Consts
        private const string asxWithMeta_FooToBar =
        @"
            <asx>
              <entry>
                <param name=""Foo"" value=""Bar"" />
              </entry>
            </asx>
        ";

        private const string asxWithTitle_Foo =
        @"
            <asx>
              <title>Foo</title>
            </asx>
        ";

        private const string asxWithVersion_Foo =
        @"
            <asx version=""Foo"">
            </asx>
        ";

        private const string asxWithRef_Foo =
        @"
            <asx>
              <entry>
                <ref href=""Foo"" />
              </entry>
            </asx>
        ";
        #endregion Xml Consts
    }
}
