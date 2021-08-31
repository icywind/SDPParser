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
using io.agora.sdp;
using Newtonsoft.Json;

namespace sdptests
{
    public class ConnectionTest
    {
        const string teststr = "c=IN IP4 224.2.17.12/127";
        const string expected = "{\"nettype\":\"IN\",\"addrtype\":\"IP4\",\"address\":\"224.2.17.12/127\"}";

        [Fact]
        public void CanParse()
        {
            io.agora.sdp.Record rec = Parser.ParseLine(teststr, 1);
            Parser parser = new Parser();
            var connection = parser.ParseConnection(rec);
            string json = JsonConvert.SerializeObject(connection);

            Console.WriteLine("JSON    :" + json);
            Console.WriteLine("expected:" + json);
            Assert.Equal(json, expected);
        }
    }
}
