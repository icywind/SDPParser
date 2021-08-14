//
// SessionTypes.cs
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

using System.Collections.Generic;

namespace io.agora.sdp
{
    /// <summary>
    ///    RFC 4566 Specs:
    //Session description
    //         v=  (protocol version)
    //         o = (originator and session identifier)
    //         s=  (session name)
    //         i = *(session information)
    //         u=* (URI of description)
    //         e=* (email address)
    //         p = *(phone number)
    //         c=* (connection information -- not required if included in
    //              all media)
    //         b=* (zero or more bandwidth information lines)
    //         One or more time descriptions("t=" and "r=" lines; see below)
    //         z=* (time zone adjustments)
    //         k=* (encryption key)
    //         a = *(zero or more session attribute lines)
    //         Zero or more media descriptions
    //
    //      Time description
    //         t = (time the session is active)
    //         r=* (zero or more repeat times)
    //
    //      Media description, if present
    //         m = (media name and transport address)
    //         i=* (media title)
    //         c = *(connection information -- optional if included at
    //              session level)
    //         b=* (zero or more bandwidth information lines)
    //         k=* (encryption key)
    //         a = *(zero or more media attribute lines)
    /// </summary>
    public class SessionDescription
    {
        /// <summary>
        /// The "v=" field gives the version of the Session Description Protocol.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// The "o=" field gives the originator of the session (her username and
        /// the address of the user's host) plus a session identifier and version
        /// number
        /// </summary>
        public Origin Origin { get; set; }

        /// <summary>
        /// The "s=" field is the textual session name.
        /// </summary>
        public string SessionName { get; set; }

        /// <summary>
        /// The "i=" field provides textual information about the session
        /// </summary>
        public string SessionInformation { get; set; }

        public string Uri { get; set; }

        public IList<string> EmailNumbers { get; set; }

        public IList<string> PhoneNumbers { get; set; }

        public ConnectionData ConnectionData { get; set; }
        public IList<Bandwidth> BandWiths { get; set; }

        // Time Fields
        // SDPLib defines
        //public IList<SDPTimezoneInfo> TimeZones { get; set; }
        //public IList<TimingInfo> Timings { get; set; }
        // TS defines
        public IList<TimeField> TimeFields { get; set; }

        // Key
        public EncriptionKey EncriptionKey { get; set; }

        public IList<string> Attributes { get; set; }

        public IList<MediaDescription> MediaDescriptions { get; set; }

        //public IList<RepeatTime> SDPRepeatTimes { get; set; }
    }

    public class Origin
    {
        public string UserName { get; set; }
        public ulong SessionId { get; set; }
        public ulong SessionVersion { get; set; }
        public string Nettype { get; set; }
        public string AddrType { get; set; }
        public string UnicastAddress { get; set; }
    }

    public class Bandwidth
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class ConnectionData
    {
        public string Nettype { get; set; }

        public string AddrType { get; set; }

        public string ConnectionAddress { get; set; }
    }

    public class EncriptionKey
    {
        public const string ClearMethod = "clear";
        public const string Base64Method = "base64";
        public const string UriMethod = "uri";
        public const string PromptMethod = "prompt";

        public string Method { get; set; }
        public string Value { get; set; }
    }

    public class MediaDescription
    {
        public string Media { get; set; }

        public string Port { get; set; }

        public string Proto { get; set; }

        public IList<string> Fmts { get; set; }

        public string Title { get; set; }

        public ConnectionData ConnectionInfo { get; set; }

        public IList<Bandwidth> Bandwiths { get; set; }

        public EncriptionKey EncriptionKey { get; set; }

        public IList<string> Attributes { get; set; }
    }


    // SDPLib define
    public class SDPTimezoneInfo
    {
        public long AdjustmentTime { get; set; }
        public string Offset { get; set; }
    }

    // SDPLib define
    public class TimingInfo
    {
        public ulong StartTime { get; set; }
        public ulong StopTime { get; set; }
    }

    public class TimeField
    {
        public TimingInfo Time { get; set; }
    }

    public class Repeat
    {
        public string RepeatInterval { get; set; }
        public IList<string> TypeTimes { get; set; }
    }

    public class Attribute
    {
        public bool? ignored {get; set;}
  public string attField { get; set; }
  public string attValue { get; set; }
    public int _cur;
    }
    // This is internal use
    public class Record
    {
        public RECORD_TYPE type;
        public string value;
        public int cur;
        public int line;
    }
}