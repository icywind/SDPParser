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
    public class MediaAttributeTest
    {
        //string expected = "";
        List<string> SampleSDPText = new List<string> {
            //"m = video 9 UDP/TLS/RTP/SAVPF 96 97 98 99 100 101 102 121 127 120 125 107 108 109 124 119 123 118 114 115 116",
            "m=video 4700 RTP/SAVPF 96",
            "c=IN IP4 58.211.82.4",
            "a=rtcp:4700 IN IP4 58.211.82.4",
            "a=candidate:1 1 udp 2103266323 58.211.82.4 4700 typ host generation 0",
            "a=candidate:1 2 udp 2103266323 58.211.82.4 4700 typ host generation 0",
            "a=remote-candidates:1 192.0.2.3 45664",
            "a=remote-candidates:2 192.0.2.3 45665",
            "a=ice-ufrag:zuXp",
            "a=ice-pwd:NaYeZ7O1ZH/0U5m+Lz2sxV5m",
            "a=ice-lite",
            "a=ice-options:rtp+ecn",
            "a=extmap:2 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time",
            "a=extmap:3 urn:3gpp:video-orientation",
            "a=x-google-flag:conference",
            "a=fingerprint:sha-256 E8:3B:64:86:19:EC:D9:7E:70:C3:B0:DB:AD:13:F5:B1:B4:9A:34:17:A1:B9:D9:2D:D0:92:12:E3:2D:F8:E3:B5",
            "a=sendrecv",
            "a=mid:0",
            "a=rtcp-mux",
            "a=rtpmap:96 VP8/90000",
            "a=fmtp:96      ",
            "a=rtcp-fb:96 ccm fir",
            "a=rtcp-fb:96 nack",
            "a=rtcp-fb:96 nack pli",
            "a=rtcp-fb:96 goog-remb",
            "a=ssrc:55543 cname:o/i14u9pJrxRKAsu",
            "a=ssrc:55543 msid:oTwikEfJsd v0",
            "a=ssrc:55543 mslabel:oTwikEfJsd",
            "a=rid:1 send pt=97 max-width=1280;max-height=720",
            "a=rid:2 send pt=98 max-width=320;max-height=180",
            "a=rid:3 send pt=99 max-width=320;max-height=180",
            "a=ssrc:55543 label:oTwikEfJsdv0" 
        };

        private Parser InjectRecords()
        {
            int c = 0; 
            List<io.agora.sdp.Record> records = new List<io.agora.sdp.Record>();

            //expected = "";
            //Console.WriteLine("Expected:" + expected);

            foreach(string line in SampleSDPText)
            {
                io.agora.sdp.Record rec = Parser.ParseLine(line, c++);
                records.Add(rec);
	        }

            return new Parser(records);
	    }

        [Fact]
        public void ParseMedia()
        {
            io.agora.sdp.Record rec = Parser.ParseLine(SampleSDPText[0], 0);
            Parser parser = new Parser();
            var result = parser.ParseMedia(rec);

            Console.WriteLine("result = \n" + result.ToString());
        }

        [Fact]
        public void ParseMediaAttribute()
        {
            Parser parser = InjectRecords();
            var Attributes = parser.ParseMediaDescription();
            string json = JsonConvert.SerializeObject(Attributes);
            Console.WriteLine("Attributes:\n" + json);
        }

        // Attribute inside Media
        [Fact]
        public void ParseRid()
        {
            var parser = new MediaAttributeParser();
            io.agora.sdp.Attribute attribute = new io.agora.sdp.Attribute(
                 "rid", 0, "1 send pt = 97 max - width = 1280; max - height = 720"
                ); 
	
            parser.ParseRid(attribute);
	    }
    }
}
