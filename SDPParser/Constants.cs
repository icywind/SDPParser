//
// Constants.cs
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
namespace io.agora.sdp
{
    public class Constants
    {
        public const char CR = '\u000D';
        public const char LF = '\u000A';
        public const char NUL = '\u0000';
        public const char SP = '\u0020';
        public const string CRLF = "${CR}${LF}";
    }

    public class RECORD_TYPE
    {
        public const char VERSION = 'v';
        public const char ORIGIN  = 'o';
        public const char SESSION_NAME = 's';
        public const char INFORMATION = 'i';
        public const char URI = 'u';
        public const char EMAIL = 'e';
        public const char PHONE = 'p';
        public const char CONNECTION = 'c';
        public const char BANDWIDTH = 'b';
        public const char TIME  = 't';
        public const char REPEAT = 'r';
        public const char ZONE_ADJUSTMENTS = 'z';
        public const char KEY = 'k';
        public const char ATTRIBUTE = 'a';
        public const char MEDIA = 'm';
    }
}


