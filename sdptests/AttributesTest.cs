//
// AttributesTest.cs
//
// Author:
//       Rick Cheng <rick@agora.io>
//
// Copyright (c) 2021 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using Xunit;
using System;
using System.Collections.Generic;
using io.agora.sdp;
using Newtonsoft.Json;

namespace sdptests
{
    public class AttributesTest
    {
        //string expected = "";
        List<string> Attributes = new List<string> {
            //"a=X-ConferenceModel: foo 01234567890987654321098765432109876543210"

            //"a=group:BUNDLE 0",
            //"a=msid-semantic: WMS oTwikEfJsd"

"a=rtcp:9 IN IP4 0.0.0.0",
"a=ice-ufrag:YHyB",
"a=ice-pwd:/cwwsrNDxv8Hjo8B4YEsKr/m",
"a=ice-options:trickle",
"a=fingerprint:sha-256 30:01:8C:A3:73:98:71:5F:5E:EF:E3:1E:36:E8:BA:73:48:F6:20:10:C7:D2:BC:FB:EF:B3:B3:C1:96:37:87:C3",
"a=setup:actpass",
"a=mid:0",
"a=extmap:1 urn:ietf:params:rtp-hdrext:toffset",
"a=extmap:2 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time",
"a=extmap:3 urn:3gpp:video-orientation",
"a=extmap:4 http://www.ietf.org/id/draft-holmer-rmcat-transport-wide-cc-extensions-01",
"a=extmap:5 http://www.webrtc.org/experiments/rtp-hdrext/playout-delay",
"a=extmap:6 http://www.webrtc.org/experiments/rtp-hdrext/video-content-type",
"a=extmap:7 http://www.webrtc.org/experiments/rtp-hdrext/video-timing",
"a=extmap:8 http://www.webrtc.org/experiments/rtp-hdrext/color-space",
"a=extmap:9 urn:ietf:params:rtp-hdrext:sdes:mid",
"a=extmap:10 urn:ietf:params:rtp-hdrext:sdes:rtp-stream-id",
"a=extmap:11 urn:ietf:params:rtp-hdrext:sdes:repaired-rtp-stream-id"
        };

        private Parser InjectAttributes()
        {
            int c = 0; 
            List<io.agora.sdp.Record> records = new List<io.agora.sdp.Record>();

            //expected = "";
            //Console.WriteLine("Expected:" + expected);

            foreach(string line in Attributes)
            {
                io.agora.sdp.Record rec = Parser.ParseLine(line, c++);
                records.Add(rec);
	        }

            return new Parser(records);
	    }

        [Fact]
        public void CanParse()
        {
            Parser parser = InjectAttributes();
            var Attributes = parser.ParseSessionAttribute();
            string json = JsonConvert.SerializeObject(Attributes);
            Console.WriteLine("Attributes:\n" + json);

            // Assert.Equal(json, expected);
        }
    }
}
