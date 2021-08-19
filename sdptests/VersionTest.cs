using Xunit;
using System.Collections.Generic;
using io.agora.sdp;

namespace sdptests
{
    public class VersionTest
    {
        [Fact]
        public void CanDeSerialize()
        {
            string expected = SampleSDP.SDP1;
            Parser parser = new Parser();
            SessionDescription sessionDescription = parser.Parse(expected);
        }

        [Fact]
        public void CanPrint()
        {
            List<int> list = new List<int>() { 1 };
            Assert.NotEmpty(list);
	    }
    }
}
