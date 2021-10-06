//
// TestParser.cs
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
using io.agora.sdp;
using Newtonsoft.Json;

namespace sdptests
{
    public class TestParser
    {
        public SessionDescription SessionDescriptionBuffer { get; protected set; }

        public string ParseSDP(string sdp)
        {
            Parser parser = new Parser();
            SessionDescriptionBuffer = parser.Parse(sdp);
            string json = JsonConvert.SerializeObject(SessionDescriptionBuffer);
            Console.WriteLine("sessionDescription:\n" + json);
            return json;
        }

        [Fact]
        protected void TestSDP1()
        {
            ParseSDP(SampleSDP.SDP1);
	    }

        [Fact]
        protected void TestSDP2()
        {
            ParseSDP(SampleSDP.SDP2);
        }

        [Fact]
        protected void TestSDP3()
        {
            ParseSDP(SampleSDP.SDP3);
        }

        [Fact]
        protected void TestSDP8()
        {
            ParseSDP(SampleSDP.SDP8);
        }
    }
}
