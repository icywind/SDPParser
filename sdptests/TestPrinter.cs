﻿//
// TestPrinter.cs
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
    public class TestPrinter
    {
        TestParser testParser = new TestParser();

        [Fact]
        void PrintSDP1()
        {
            testParser.ParseSDP(SampleSDP.SDP1);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer, "\n");
            Console.WriteLine(sdp);
        }

        [Fact]
        void PrintSDP2()
        {
            testParser.ParseSDP(SampleSDP.SDP2);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }

        [Fact]
        void PrintSDP3()
        {
            testParser.ParseSDP(SampleSDP.SDP3);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }


        [Fact]
        void PrintSDP4()
        {
            testParser.ParseSDP(SampleSDP.SDP4);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }

        [Fact]
        void PrintSDP5()
        {
            testParser.ParseSDP(SampleSDP.SDP5);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }

        [Fact]
        void PrintSDP6()
        {
            testParser.ParseSDP(SampleSDP.SDP6);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }


        [Fact]
        void PrintSDP7()
        {
            testParser.ParseSDP(SampleSDP.SDP7);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }

        [Fact]
        void PrintSDP8()
        {
            testParser.ParseSDP(SampleSDP.SDP8);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }


        [Fact]
        void PrintSDP9()
        {
            testParser.ParseSDP(SampleSDP.SDP9);
            string sdp = Printer.Print(testParser.SessionDescriptionBuffer);
            Console.WriteLine(sdp);
        }
    }
}
