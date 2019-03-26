using System;
using System.Linq;
using NPlaylist.Asx;
using Xunit;

namespace NPlaylist.Tests.Asx
{
    public class AsxSerializerTests
    {
        [Fact]
        public void Serialize_NullInput_ThrowException()
        {
            var serializer = new AsxSerializer();

            var output = serializer.Serialize(null);
            Assert.True(output == String.Empty);
        }

        [Fact]
        public void Serialize_VersionIsParsedAsExpected()
        {
            var playlist = new AsxPlaylist {Version = "1.0"};
            var serializer = new AsxSerializer();

            var asxWithVersion = @"<asx version=""1.0"" />";

            var output = serializer.Serialize(playlist);
            Assert.True(output == asxWithVersion);
        }

        [Fact]
        public void Serialize_TitleOnlyIsParsedAsExpected_Foo()
        {
            var playlist = new AsxPlaylist { Title = "Foo" };

            var serializer = new AsxSerializer();
            var asxWithTitle = @"<title>Foo</title>";

            var output = serializer.Serialize(playlist);
            Assert.Contains(asxWithTitle, output);
        }

        [Fact]
        public void Serialize_EmptyEntryIsParsed()
        {
            var playlist = new AsxPlaylist();
            playlist.Add(new AsxItem(string.Empty));

            var serializer = new AsxSerializer();
            var cleanAsx = @"<asx />";

            var output = serializer.Serialize(playlist);
            Assert.True(output == cleanAsx);
        }

        [Fact]
        public void Serialize_OnlyParamIsParsed_FooToBar()
        {
            var playlist = new AsxPlaylist();
            playlist.Add(new AsxItem(string.Empty));
            var asxItem = playlist.Items.First();
            asxItem.Tags["Foo"] = "Bar";

            var serializer = new AsxSerializer();
            var asxWithVersion = @"<asx />";

            var output = serializer.Serialize(playlist);
            Assert.True(output == asxWithVersion);
        }
    }
}
