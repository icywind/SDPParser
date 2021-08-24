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
    public class TimeFieldTest
    {
        string expected = "[{\"time\":{\"startTime\":\"2873397496\",\"stopTime\":\"2873404696\"},\"repeats\":null,\"zoneAdjustments\":null}]";
        List<string> _TimeField = new List<string> {
            "t = 2873397496 2873404696"
        };

        private Parser InjectTimeField()
        {
            int c = 5; 
            List<io.agora.sdp.Record> records = new List<io.agora.sdp.Record>();


            foreach(string line in _TimeField)
            {
                io.agora.sdp.Record rec = Parser.ParseLine(line, c++);
                records.Add(rec);
	        }

            return new Parser(records);
	    }

        [Fact]
        public void CanParse()
        {
            Parser parser = InjectTimeField();
            IList<TimeField> TimeFields = parser.ParseTimeFields();
            string json = JsonConvert.SerializeObject(TimeFields);
            Console.WriteLine("TimeField:  " + json);
            Console.WriteLine("Expected:   " + expected);

            Assert.Equal(json, expected);
        }
    }
}
