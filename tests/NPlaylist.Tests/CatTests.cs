using FluentAssertions;
using Xunit;

namespace NPlaylist.Tests
{
    public class CatTests
    {
        [Fact]
        public void Meow_Returns_ExpectedString()
        {
            var cat = new Cat();

            var actual = cat.Meow();

            actual.Should().Be("Meow!");
        }
    }
}
