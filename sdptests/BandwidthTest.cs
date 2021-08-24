//
// SessionNameTest.cs
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
    public class BandwidthTest
    {
        string expected = "[{\"bwtype\":\"AS\",\"bandwidth\":\"256\"},{\"bwtype\":\"RR\",\"bandwidth\":\"800\"},{\"bwtype\":\"RS\",\"bandwidth\":\"2400\"}]";
        List<string> _Bandwidth = new List<string> {
             "b=AS:256", 
	         "b=RR:800",
	         "b=RS:2400"
        };

        private Parser InjectBandwidth()
        {
            int c = 5; 
            List<io.agora.sdp.Record> records = new List<io.agora.sdp.Record>();


            foreach(string band in _Bandwidth)
            {
                io.agora.sdp.Record rec = Parser.ParseLine(band, c++);
                records.Add(rec);
	        }

            return new Parser(records);
	    }

        [Fact]
        public void CanParse()
        {
            Parser parser = InjectBandwidth();
            IList<Bandwidth> Bandwidths = parser.ParseBandWidth();
            string json = JsonConvert.SerializeObject(Bandwidths);
            Console.WriteLine("Bandwidth:  " + json);
            Console.WriteLine("Expected:   " + json);

            Assert.Equal(json, expected);
        }
    }
}
