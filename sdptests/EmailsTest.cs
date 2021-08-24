//
// EmailsTest.cs
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
    public class EmailsTest
    {
        string expected = "";
        List<string> emails = new List<string> { 
	        //"e=j.doe@example.com (Jane Doe)",
	        "j.doe@example.com (Jane Doe)",
	        "mario@nindo.com (Mario)" 
	    };

        private Parser InjectEmails()
        {
            int c = 5; 
            List<io.agora.sdp.Record> records = new List<io.agora.sdp.Record>();

            expected = "[\"" + string.Join("\",\"", emails) + "\"]";
            Console.WriteLine("Expected:" + expected);

            foreach(string email in emails)
            {
                io.agora.sdp.Record rec = Parser.ParseLine("e=" + email, c++);
                records.Add(rec);
	        }

            return new Parser(records);
	    }

        [Fact]
        public void CanParse()
        {
            Parser parser = InjectEmails();
            IList<string> emails = parser.ParseEmail();
            string emailJson = JsonConvert.SerializeObject(emails);
            Console.WriteLine("Emails:  " + emailJson);

            Assert.Equal(emailJson, expected);
        }
    }
}
