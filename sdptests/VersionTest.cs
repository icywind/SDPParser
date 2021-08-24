using Xunit;
using io.agora.sdp;
using System;

namespace sdptests
{
    public class VersionTest
    {
        const string teststr = "v=100";
        const string expected = "100";

        [Fact]
        public void CanParse()
        {
            io.agora.sdp.Record rec = Parser.ParseLine(teststr, 0);
            Parser parser = new Parser();
            var ver = parser.ParseVersion(rec);

            Console.WriteLine("Version = " + ver);

            Assert.Equal(ver.ToString(), expected);
        }
    }
}


