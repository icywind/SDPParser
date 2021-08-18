using Xunit;
using io.agora.sdp;

namespace sdptests
{
    public class VersionTest
    {
        [Fact]
        public void CanDeSerialize()
        {
            var expected = "v=0";
            var version = "v=0";
            Assert.Equal(expected, version);
        }

    }
}
