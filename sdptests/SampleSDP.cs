//
// SampleSDP.cs
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
using System;
namespace sdptests
{
    public class SampleSDP
    {
        public const string SDP1 = @"
v=0
o=- 0 0 IN IP4 127.0.0.1
s=AgoraGateway
t = 0 0
a=group:BUNDLE 0
a=msid-semantic: WMS oTwikEfJsd
m=video 4700 RTP/SAVPF 96
c=IN IP4 58.211.82.4
a=rtcp:4700 IN IP4 58.211.82.4
a=candidate:1 1 udp 2103266323 58.211.82.4 4700 typ host generation 0
a=candidate:1 2 udp 2103266323 58.211.82.4 4700 typ host generation 0
a=remote-candidates:1 192.0.2.3 45664
a=remote-candidates:2 192.0.2.3 45665
a=ice-ufrag:zuXp
a = ice - pwd:NaYeZ7O1ZH/0U5m+Lz2sxV5m
a = ice - lite
a=ice-options:rtp+ecn
a = extmap:2 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time
a=extmap:3 urn:3gpp:video-orientation
a = x - google - flag:conference
a = fingerprint:sha-256 E8:3B:64:86:19:EC:D9:7E:70:C3:B0:DB:AD:13:F5:B1:B4:9A:34:17:A1:B9:D9:2D:D0:92:12:E3:2D:F8:E3:B5
a = sendrecv
a=mid:0
a=rtcp-mux
a = rtpmap:96 VP8/90000
a=fmtp:96      
a=rtcp-fb:96 ccm fir
a=rtcp-fb:96 nack
a = rtcp - fb:96 nack pli
a=rtcp-fb:96 goog-remb
a = ssrc:55543 cname:o/i14u9pJrxRKAsu
a = ssrc:55543 msid:oTwikEfJsd v0
a=ssrc:55543 mslabel:oTwikEfJsd
a = rid:1 send pt = 97 max-width=1280;max-height=720
a=rid:2 send pt = 98 max-width=320;max-height=180
a=rid:3 send pt = 99 max-width=320;max-height=180
a=ssrc:55543 label:oTwikEfJsdv0";

public const string SDP2 = @"
v=0
o=- 788349932267013171 2 IN IP4 127.0.0.1
s=-
t=0 0
a=group:BUNDLE 0
a=msid-semantic: WMS
m = video 9 UDP/TLS/RTP/SAVPF 96 97 98 99 100 101 102 121 127 120 125 107 108 109 124 119 123 118 114 115 116
c=IN IP4 0.0.0.0
a=rtcp:9 IN IP4 0.0.0.0
a=ice-ufrag:YHyB
a = ice - pwd:/cwwsrNDxv8Hjo8B4YEsKr/m
a = ice - options:trickle
a = fingerprint:sha-256 30:01:8C:A3:73:98:71:5F:5E:EF:E3:1E:36:E8:BA:73:48:F6:20:10:C7:D2:BC:FB:EF:B3:B3:C1:96:37:87:C3
a = setup:actpass
a = mid:0
a=extmap:1 urn:ietf:params:rtp-hdrext:toffset
a = extmap:2 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time
a=extmap:3 urn:3gpp:video-orientation
a = extmap:4 http://www.ietf.org/id/draft-holmer-rmcat-transport-wide-cc-extensions-01
a=extmap:5 http://www.webrtc.org/experiments/rtp-hdrext/playout-delay
a=extmap:6 http://www.webrtc.org/experiments/rtp-hdrext/video-content-type
a=extmap:7 http://www.webrtc.org/experiments/rtp-hdrext/video-timing
a=extmap:8 http://www.webrtc.org/experiments/rtp-hdrext/color-space
a=extmap:9 urn:ietf:params:rtp-hdrext:sdes:mid
a = extmap:10 urn:ietf:params:rtp-hdrext:sdes:rtp-stream-id
a = extmap:11 urn:ietf:params:rtp-hdrext:sdes:repaired-rtp-stream-id
a = sendrecv
a=msid:- d49f05f2-9134-4789-91c0-5a6c086fd647
a = rtcp - mux
a=rtcp-rsize
a = rtpmap:96 VP8/90000
a=rtcp-fb:96 goog-remb
a = rtcp - fb:96 transport-cc
a = rtcp - fb:96 ccm fir
a=rtcp-fb:96 nack
a = rtcp - fb:96 nack pli
a=rtpmap:97 rtx/90000
a=fmtp:97 apt=96
a=rtpmap:98 VP9/90000
a=rtcp-fb:98 goog-remb
a = rtcp - fb:98 transport-cc
a = rtcp - fb:98 ccm fir
a=rtcp-fb:98 nack
a = rtcp - fb:98 nack pli
a=fmtp:98 profile-id=0
a=rtpmap:99 rtx/90000
a=fmtp:99 apt=98
a=rtpmap:100 VP9/90000
a=rtcp-fb:100 goog-remb
a = rtcp - fb:100 transport-cc
a = rtcp - fb:100 ccm fir
a=rtcp-fb:100 nack
a = rtcp - fb:100 nack pli
a=fmtp:100 profile-id=2
a=rtpmap:101 rtx/90000
a=fmtp:101 apt=100
a=rtpmap:102 H264/90000
a=rtcp-fb:102 goog-remb
a = rtcp - fb:102 transport-cc
a = rtcp - fb:102 ccm fir
a=rtcp-fb:102 nack
a = rtcp - fb:102 nack pli
a=fmtp:102 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42001f
a=rtpmap:121 rtx/90000
a=fmtp:121 apt=102
a=rtpmap:127 H264/90000
a=rtcp-fb:127 goog-remb
a = rtcp - fb:127 transport-cc
a = rtcp - fb:127 ccm fir
a=rtcp-fb:127 nack
a = rtcp - fb:127 nack pli
a=fmtp:127 level-asymmetry-allowed=1;packetization-mode=0;profile-level-id=42001f
a=rtpmap:120 rtx/90000
a=fmtp:120 apt=127
a=rtpmap:125 H264/90000
a=rtcp-fb:125 goog-remb
a = rtcp - fb:125 transport-cc
a = rtcp - fb:125 ccm fir
a=rtcp-fb:125 nack
a = rtcp - fb:125 nack pli
a=fmtp:125 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42e01f
a=rtpmap:107 rtx/90000
a=fmtp:107 apt=125
a=rtpmap:108 H264/90000
a=rtcp-fb:108 goog-remb
a = rtcp - fb:108 transport-cc
a = rtcp - fb:108 ccm fir
a=rtcp-fb:108 nack
a = rtcp - fb:108 nack pli
a=fmtp:108 level-asymmetry-allowed=1;packetization-mode=0;profile-level-id=42e01f
a=rtpmap:109 rtx/90000
a=fmtp:109 apt=108
a=rtpmap:124 H264/90000
a=rtcp-fb:124 goog-remb
a = rtcp - fb:124 transport-cc
a = rtcp - fb:124 ccm fir
a=rtcp-fb:124 nack
a = rtcp - fb:124 nack pli
a=fmtp:124 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=4d0032
a=rtpmap:119 rtx/90000
a=fmtp:119 apt=124
a=rtpmap:123 H264/90000
a=rtcp-fb:123 goog-remb
a = rtcp - fb:123 transport-cc
a = rtcp - fb:123 ccm fir
a=rtcp-fb:123 nack
a = rtcp - fb:123 nack pli
a=fmtp:123 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=640032
a=rtpmap:118 rtx/90000
a=fmtp:118 apt=123
a=rtpmap:114 red/90000
a=rtpmap:115 rtx/90000
a=fmtp:115 apt=114
a=rtpmap:116 ulpfec/90000
a=ssrc-group:FID 3104457674 214134762
a=ssrc:3104457674 cname:uuCSZpHdKeFrsvZx
a = ssrc:3104457674 msid:- d49f05f2-9134-4789-91c0-5a6c086fd647
a = ssrc:3104457674 mslabel:-
a=ssrc:3104457674 label:d49f05f2-9134-4789-91c0-5a6c086fd647
a = ssrc:214134762 cname:uuCSZpHdKeFrsvZx
a = ssrc:214134762 msid:- d49f05f2-9134-4789-91c0-5a6c086fd647
a = ssrc:214134762 mslabel:-
a=ssrc:214134762 label:d49f05f2-9134-4789-91c0-5a6c086fd647";

public const string SDP3 = @"
v=0
o=- 3827731648519876250 2 IN IP4 127.0.0.1
s=-
t=0 0
a=group:BUNDLE 0 1
a=msid-semantic: WMS
m = video 9 UDP/TLS/RTP/SAVPF 96 97 98 99 100 101 102 121 127 120 125 107 108 109 124 119 123 118 114 115 116
c=IN IP4 0.0.0.0
a=rtcp:9 IN IP4 0.0.0.0
a=ice-ufrag:kTya
a = ice - pwd:2KkS8DX20s5bLq9WM1RDFeXb
a = ice - options:trickle
a = fingerprint:sha-256 66:88:17:05:78:2D:F4:A7:D1:E8:97:3B:43:96:63:AF:2E:A0:CE:61:FE:76:61:0D:62:FA:3C:71:CD:66:64:A9
a = setup:actpass
a = mid:0
a=extmap:1 urn:ietf:params:rtp-hdrext:toffset
a = extmap:2 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time
a=extmap:3 urn:3gpp:video-orientation
a = extmap:4 http://www.ietf.org/id/draft-holmer-rmcat-transport-wide-cc-extensions-01
a=extmap:5 http://www.webrtc.org/experiments/rtp-hdrext/playout-delay
a=extmap:6 http://www.webrtc.org/experiments/rtp-hdrext/video-content-type
a=extmap:7 http://www.webrtc.org/experiments/rtp-hdrext/video-timing
a=extmap:8 http://www.webrtc.org/experiments/rtp-hdrext/color-space
a=extmap:9 urn:ietf:params:rtp-hdrext:sdes:mid
a = extmap:10 urn:ietf:params:rtp-hdrext:sdes:rtp-stream-id
a = extmap:11 urn:ietf:params:rtp-hdrext:sdes:repaired-rtp-stream-id
a = sendrecv
a=msid:- 461df4c8-8bf8-4557-82cd-6dd6de2d43fa
a = rtcp - mux
a=rtcp-rsize
a = rtpmap:96 VP8/90000
a=rtcp-fb:96 goog-remb
a = rtcp - fb:96 transport-cc
a = rtcp - fb:96 ccm fir
a=rtcp-fb:96 nack
a = rtcp - fb:96 nack pli
a=rtpmap:97 rtx/90000
a=fmtp:97 apt=96
a=rtpmap:98 VP9/90000
a=rtcp-fb:98 goog-remb
a = rtcp - fb:98 transport-cc
a = rtcp - fb:98 ccm fir
a=rtcp-fb:98 nack
a = rtcp - fb:98 nack pli
a=fmtp:98 profile-id=0
a=rtpmap:99 rtx/90000
a=fmtp:99 apt=98
a=rtpmap:100 VP9/90000
a=rtcp-fb:100 goog-remb
a = rtcp - fb:100 transport-cc
a = rtcp - fb:100 ccm fir
a=rtcp-fb:100 nack
a = rtcp - fb:100 nack pli
a=fmtp:100 profile-id=2
a=rtpmap:101 rtx/90000
a=fmtp:101 apt=100
a=rtpmap:102 H264/90000
a=rtcp-fb:102 goog-remb
a = rtcp - fb:102 transport-cc
a = rtcp - fb:102 ccm fir
a=rtcp-fb:102 nack
a = rtcp - fb:102 nack pli
a=fmtp:102 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42001f
a=rtpmap:121 rtx/90000
a=fmtp:121 apt=102
a=rtpmap:127 H264/90000
a=rtcp-fb:127 goog-remb
a = rtcp - fb:127 transport-cc
a = rtcp - fb:127 ccm fir
a=rtcp-fb:127 nack
a = rtcp - fb:127 nack pli
a=fmtp:127 level-asymmetry-allowed=1;packetization-mode=0;profile-level-id=42001f
a=rtpmap:120 rtx/90000
a=fmtp:120 apt=127
a=rtpmap:125 H264/90000
a=rtcp-fb:125 goog-remb
a = rtcp - fb:125 transport-cc
a = rtcp - fb:125 ccm fir
a=rtcp-fb:125 nack
a = rtcp - fb:125 nack pli
a=fmtp:125 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42e01f
a=rtpmap:107 rtx/90000
a=fmtp:107 apt=125
a=rtpmap:108 H264/90000
a=rtcp-fb:108 goog-remb
a = rtcp - fb:108 transport-cc
a = rtcp - fb:108 ccm fir
a=rtcp-fb:108 nack
a = rtcp - fb:108 nack pli
a=fmtp:108 level-asymmetry-allowed=1;packetization-mode=0;profile-level-id=42e01f
a=rtpmap:109 rtx/90000
a=fmtp:109 apt=108
a=rtpmap:124 H264/90000
a=rtcp-fb:124 goog-remb
a = rtcp - fb:124 transport-cc
a = rtcp - fb:124 ccm fir
a=rtcp-fb:124 nack
a = rtcp - fb:124 nack pli
a=fmtp:124 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=4d0032
a=rtpmap:119 rtx/90000
a=fmtp:119 apt=124
a=rtpmap:123 H264/90000
a=rtcp-fb:123 goog-remb
a = rtcp - fb:123 transport-cc
a = rtcp - fb:123 ccm fir
a=rtcp-fb:123 nack
a = rtcp - fb:123 nack pli
a=fmtp:123 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=640032
a=rtpmap:118 rtx/90000
a=fmtp:118 apt=123
a=rtpmap:114 red/90000
a=rtpmap:115 rtx/90000
a=fmtp:115 apt=114
a=rtpmap:116 ulpfec/90000
a=ssrc-group:FID 1996103417 1099538423
a=ssrc:1996103417 cname:di0HqC550Pd5BTIg
a = ssrc:1996103417 msid:- 461df4c8-8bf8-4557-82cd-6dd6de2d43fa
a = ssrc:1996103417 mslabel:-
a=ssrc:1996103417 label:461df4c8-8bf8-4557-82cd-6dd6de2d43fa
a = ssrc:1099538423 cname:di0HqC550Pd5BTIg
a = ssrc:1099538423 msid:- 461df4c8-8bf8-4557-82cd-6dd6de2d43fa
a = ssrc:1099538423 mslabel:-
a=ssrc:1099538423 label:461df4c8-8bf8-4557-82cd-6dd6de2d43fa
m = video 9 UDP/TLS/RTP/SAVPF 96 97 98 99 100 101 102 121 127 120 125 107 108 109 124 119 123 118 114 115 116
c=IN IP4 0.0.0.0
a=rtcp:9 IN IP4 0.0.0.0
a=ice-ufrag:kTya
a = ice - pwd:2KkS8DX20s5bLq9WM1RDFeXb
a = ice - options:trickle
a = fingerprint:sha-256 66:88:17:05:78:2D:F4:A7:D1:E8:97:3B:43:96:63:AF:2E:A0:CE:61:FE:76:61:0D:62:FA:3C:71:CD:66:64:A9
a = setup:actpass
a = mid:1
a=extmap:1 urn:ietf:params:rtp-hdrext:toffset
a = extmap:2 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time
a=extmap:3 urn:3gpp:video-orientation
a = extmap:4 http://www.ietf.org/id/draft-holmer-rmcat-transport-wide-cc-extensions-01
a=extmap:5 http://www.webrtc.org/experiments/rtp-hdrext/playout-delay
a=extmap:6 http://www.webrtc.org/experiments/rtp-hdrext/video-content-type
a=extmap:7 http://www.webrtc.org/experiments/rtp-hdrext/video-timing
a=extmap:8 http://www.webrtc.org/experiments/rtp-hdrext/color-space
a=extmap:9 urn:ietf:params:rtp-hdrext:sdes:mid
a = extmap:10 urn:ietf:params:rtp-hdrext:sdes:rtp-stream-id
a = extmap:11 urn:ietf:params:rtp-hdrext:sdes:repaired-rtp-stream-id
a = sendrecv
a=msid:- 21f97166-f15c-451f-aa53-11ed42a8075e
a = rtcp - mux
a=rtcp-rsize
a = rtpmap:96 VP8/90000
a=rtcp-fb:96 goog-remb
a = rtcp - fb:96 transport-cc
a = rtcp - fb:96 ccm fir
a=rtcp-fb:96 nack
a = rtcp - fb:96 nack pli
a=rtpmap:97 rtx/90000
a=fmtp:97 apt=96
a=rtpmap:98 VP9/90000
a=rtcp-fb:98 goog-remb
a = rtcp - fb:98 transport-cc
a = rtcp - fb:98 ccm fir
a=rtcp-fb:98 nack
a = rtcp - fb:98 nack pli
a=fmtp:98 profile-id=0
a=rtpmap:99 rtx/90000
a=fmtp:99 apt=98
a=rtpmap:100 VP9/90000
a=rtcp-fb:100 goog-remb
a = rtcp - fb:100 transport-cc
a = rtcp - fb:100 ccm fir
a=rtcp-fb:100 nack
a = rtcp - fb:100 nack pli
a=fmtp:100 profile-id=2
a=rtpmap:101 rtx/90000
a=fmtp:101 apt=100
a=rtpmap:102 H264/90000
a=rtcp-fb:102 goog-remb
a = rtcp - fb:102 transport-cc
a = rtcp - fb:102 ccm fir
a=rtcp-fb:102 nack
a = rtcp - fb:102 nack pli
a=fmtp:102 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42001f
a=rtpmap:121 rtx/90000
a=fmtp:121 apt=102
a=rtpmap:127 H264/90000
a=rtcp-fb:127 goog-remb
a = rtcp - fb:127 transport-cc
a = rtcp - fb:127 ccm fir
a=rtcp-fb:127 nack
a = rtcp - fb:127 nack pli
a=fmtp:127 level-asymmetry-allowed=1;packetization-mode=0;profile-level-id=42001f
a=rtpmap:120 rtx/90000
a=fmtp:120 apt=127
a=rtpmap:125 H264/90000
a=rtcp-fb:125 goog-remb
a = rtcp - fb:125 transport-cc
a = rtcp - fb:125 ccm fir
a=rtcp-fb:125 nack
a = rtcp - fb:125 nack pli
a=fmtp:125 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42e01f
a=rtpmap:107 rtx/90000
a=fmtp:107 apt=125
a=rtpmap:108 H264/90000
a=rtcp-fb:108 goog-remb
a = rtcp - fb:108 transport-cc
a = rtcp - fb:108 ccm fir
a=rtcp-fb:108 nack
a = rtcp - fb:108 nack pli
a=fmtp:108 level-asymmetry-allowed=1;packetization-mode=0;profile-level-id=42e01f
a=rtpmap:109 rtx/90000
a=fmtp:109 apt=108
a=rtpmap:124 H264/90000
a=rtcp-fb:124 goog-remb
a = rtcp - fb:124 transport-cc
a = rtcp - fb:124 ccm fir
a=rtcp-fb:124 nack
a = rtcp - fb:124 nack pli
a=fmtp:124 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=4d0032
a=rtpmap:119 rtx/90000
a=fmtp:119 apt=124
a=rtpmap:123 H264/90000
a=rtcp-fb:123 goog-remb
a = rtcp - fb:123 transport-cc
a = rtcp - fb:123 ccm fir
a=rtcp-fb:123 nack
a = rtcp - fb:123 nack pli
a=fmtp:123 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=640032
a=rtpmap:118 rtx/90000
a=fmtp:118 apt=123
a=rtpmap:114 red/90000
a=rtpmap:115 rtx/90000
a=fmtp:115 apt=114
a=rtpmap:116 ulpfec/90000
a=ssrc-group:FID 3189793060 1873165605
a=ssrc:3189793060 cname:di0HqC550Pd5BTIg
a = ssrc:3189793060 msid:- 21f97166-f15c-451f-aa53-11ed42a8075e
a = ssrc:3189793060 mslabel:-
a=ssrc:3189793060 label:21f97166-f15c-451f-aa53-11ed42a8075e
a = ssrc:1873165605 cname:di0HqC550Pd5BTIg
a = ssrc:1873165605 msid:- 21f97166-f15c-451f-aa53-11ed42a8075e
a = ssrc:1873165605 mslabel:-
a=ssrc:1873165605 label:21f97166-f15c-451f-aa53-11ed42a8075e";

    // Chrome SDP
    public const string SDP4 = @"
v=0
o=- 4327261771880257373 2 IN IP4 127.0.0.1
s=-
t=0 0
a=group:BUNDLE audio video
a=msid-semantic: WMS xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj
m=audio 9 UDP/TLS/RTP/SAVPF 111 103 104 9 0 8 106 105 13 110 112 113 126
c=IN IP4 0.0.0.0
a=rtcp:9 IN IP4 0.0.0.0
a=ice-ufrag:ez5G
a=ice-pwd:1F1qS++jzWLSQi0qQDZkX/QV
a=fingerprint:sha-256 D2:FA:0E:C3:22:59:5E:14:95:69:92:3D:13:B4:84:24:2C:C2:A2:C0:3E:FD:34:8E:5E:EA:6F:AF:52:CE:E6:0F
a=setup:actpass
a=connection:new
a=mid:audio
a=extmap:1 urn:ietf:params:rtp-hdrext:ssrc-audio-level
a=sendrecv
a=rtcp-mux
a=rtpmap:111 opus/48000/2
a=rtcp-fb:111 transport-cc
a=fmtp:111 minptime=10;useinbandfec=1
a=rtpmap:103 ISAC/16000
a=rtpmap:104 ISAC/32000
a=rtpmap:9 G722/8000
a=rtpmap:0 PCMU/8000
a=rtpmap:8 PCMA/8000
a=rtpmap:106 CN/32000
a=rtpmap:105 CN/16000
a=rtpmap:13 CN/8000
a=rtpmap:110 telephone-event/48000
a=rtpmap:112 telephone-event/32000
a=rtpmap:113 telephone-event/16000
a=rtpmap:126 telephone-event/8000
a=ssrc:3510681183 cname:loqPWNg7JMmrFUnr
a=ssrc:3510681183 msid:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj 7ea47500-22eb-4815-a899-c74ef321b6ee
a=ssrc:3510681183 mslabel:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj
a=ssrc:3510681183 label:7ea47500-22eb-4815-a899-c74ef321b6ee
m=video 9 UDP/TLS/RTP/SAVPF 96 98 100 102 127 125 97 99 101 124
c=IN IP4 0.0.0.0
a=connection:new
a=rtcp:9 IN IP4 0.0.0.0
a=ice-ufrag:ez5G
a=ice-pwd:1F1qS++jzWLSQi0qQDZkX/QV
a=fingerprint:sha-256 D2:FA:0E:C3:22:59:5E:14:95:69:92:3D:13:B4:84:24:2C:C2:A2:C0:3E:FD:34:8E:5E:EA:6F:AF:52:CE:E6:0F
a=setup:actpass
a=mid:video
a=extmap:2 urn:ietf:params:rtp-hdrext:toffset
a=extmap:3 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time
a=extmap:4 urn:3gpp:video-orientation
a=extmap:5 http://www.ietf.org/id/draft-holmer-rmcat-transport-wide-cc-extensions-01
a=extmap:6 http://www.webrtc.org/experiments/rtp-hdrext/playout-delay
a=sendrecv
a=rtcp-mux
a=rtcp-rsize
a=rtpmap:96 VP8/90000
a=rtcp-fb:96 ccm fir
a=rtcp-fb:96 nack
a=rtcp-fb:96 nack pli
a=rtcp-fb:96 goog-remb
a=rtcp-fb:96 transport-cc
a=rtpmap:98 VP9/90000
a=rtcp-fb:98 ccm fir
a=rtcp-fb:98 nack
a=rtcp-fb:98 nack pli
a=rtcp-fb:98 goog-remb
a=rtcp-fb:98 transport-cc
a=rtpmap:100 H264/90000
a=rtcp-fb:100 ccm fir
a=rtcp-fb:100 nack
a=rtcp-fb:100 nack pli
a=rtcp-fb:100 goog-remb
a=rtcp-fb:100 transport-cc
a=fmtp:100 level-asymmetry-allowed=1;packetization-mode=1;profile-level-id=42e01f
a=rtpmap:102 red/90000
a=rtpmap:127 ulpfec/90000
a=rtpmap:125 flexfec-03/90000
a=rtcp-fb:125 ccm fir
a=rtcp-fb:125 nack
a=rtcp-fb:125 nack pli
a=rtcp-fb:125 goog-remb
a=rtcp-fb:125 transport-cc
a=fmtp:125 repair-window=10000000
a=rtpmap:97 rtx/90000
a=fmtp:97 apt=96
a=rtpmap:99 rtx/90000
a=fmtp:99 apt=98
a=rtpmap:101 rtx/90000
a=fmtp:101 apt=100
a=rtpmap:124 rtx/90000
a=fmtp:124 apt=102
a=ssrc-group:FID 3004364195 1126032854
a=ssrc-group:FEC-FR 3004364195 1080772241
a=ssrc:3004364195 cname:loqPWNg7JMmrFUnr
a=ssrc:3004364195 msid:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj cf093ab0-0b28-4930-8fe1-7ca8d529be25
a=ssrc:3004364195 mslabel:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj
a=ssrc:3004364195 label:cf093ab0-0b28-4930-8fe1-7ca8d529be25
a=ssrc:1126032854 cname:loqPWNg7JMmrFUnr
a=ssrc:1126032854 msid:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj cf093ab0-0b28-4930-8fe1-7ca8d529be25
a=ssrc:1126032854 mslabel:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj
a=ssrc:1126032854 label:cf093ab0-0b28-4930-8fe1-7ca8d529be25
a=ssrc:1080772241 cname:loqPWNg7JMmrFUnr
a=ssrc:1080772241 msid:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj cf093ab0-0b28-4930-8fe1-7ca8d529be25
a=ssrc:1080772241 mslabel:xIKmAwWv4ft4ULxNJGhkHzvPaCkc8EKo4SGj
a=ssrc:1080772241 label:cf093ab0-0b28-4930-8fe1-7ca8d529be25
";
    // Firefox SDP
    public const string SDP5 = @"
v=0
o=mozilla...THIS_IS_SDPARTA-48.0.2 9127260475635174214 0 IN IP4 0.0.0.0
s=-
t=0 0
a=fingerprint:sha-256 1A:5E:AF:59:E2:53:C4:C1:85:9B:95:26:DF:5B:94:10:78:F6:45:B1:9C:FE:82:BD:EB:6B:45:81:44:5D:83:80
a=group:BUNDLE sdparta_0 sdparta_1
a=ice-options:trickle
a=msid-semantic:WMS *
m=audio 9 UDP/TLS/RTP/SAVPF 109 9 0 8
c=IN IP4 0.0.0.0
a=sendrecv
a=extmap:1 urn:ietf:params:rtp-hdrext:ssrc-audio-level
a=fmtp:109 maxplaybackrate=48000;stereo=1
a=ice-pwd:9ad296b1c4d8ceb0258c48c44677612a
a=ice-ufrag:cc685491
a=mid:sdparta_0
a=msid:{b96c6194-ae4a-461b-8c4f-888437515a7a} {6db3ef81-e7d1-4cb8-9ed9-4707d9bbe4cf}
a=rtcp-mux
a=rtpmap:109 opus/48000/2
a=rtpmap:9 G722/8000/1
a=rtpmap:0 PCMU/8000
a=rtpmap:8 PCMA/8000
a=setup:actpass
a=ssrc:1169438075 cname:{2b0a446c-c6af-495a-8462-d09dd2a14020}
m=video 9 UDP/TLS/RTP/SAVPF 120 126 97
c=IN IP4 0.0.0.0
a=bundle-only
a=sendrecv
a=fmtp:126 profile-level-id=42e01f;level-asymmetry-allowed=1;packetization-mode=1
a=fmtp:97 profile-level-id=42e01f;level-asymmetry-allowed=1
a=fmtp:120 max-fs=12288;max-fr=60
a=ice-pwd:9ad296b1c4d8ceb0258c48c44677612a
a=ice-ufrag:cc685491
a=mid:sdparta_1
a=msid:{b96c6194-ae4a-461b-8c4f-888437515a7a} {69e9a92d-056b-4a2d-bf58-5b26dc779cd5}
a=rtcp-fb:120 nack
a=rtcp-fb:120 nack pli
a=rtcp-fb:120 ccm fir
a=rtcp-fb:126 nack
a=rtcp-fb:126 nack pli
a=rtcp-fb:126 ccm fir
a=rtcp-fb:97 nack
a=rtcp-fb:97 nack pli
a=rtcp-fb:97 ccm fir
a=rtcp-mux
a=rtpmap:120 VP8/90000
a=rtpmap:126 H264/90000
a=rtpmap:97 H264/90000
a=setup:actpass
a=ssrc:226975506 cname:{2b0a446c-c6af-495a-8462-d09dd2a14020}
";

        // simulcast
        public const string SDP6 = @"
v=0
o=mozilla...THIS_IS_SDPARTA-56.0a1 6842103367782848290 0 IN IP4 0.0.0.0
s=-
t=0 0
a=fingerprint:sha-256 7A:23:AB:6B:FC:CA:C5:21:42:28:8C:1D:CE:CC:17:48:41:38:BD:89:A6:A0:B9:48:3F:3B:52:71:36:21:C1:0B
a=group:BUNDLE sdparta_0 sdparta_1
a=ice-options:trickle
a=msid-semantic:WMS *
m=audio 9 UDP/TLS/RTP/SAVPF 109 9 0 8 101
c=IN IP4 0.0.0.0
a=sendrecv
a=extmap:1/sendonly urn:ietf:params:rtp-hdrext:ssrc-audio-level
a=fmtp:109 maxplaybackrate=48000;stereo=1;useinbandfec=1
a=fmtp:101 0-15
a=ice-pwd:4caefce9e4e140554a3d521a2ed39d08
a=ice-ufrag:d8289e69
a=mid:sdparta_0
a=msid:{cb25209c-85a0-4206-b7fa-a60d9f86af44} {85211739-1f21-4dd9-b67f-e46cb5da7cdf}
a=rtcp-mux
a=rtpmap:109 opus/48000/2
a=rtpmap:9 G722/8000/1
a=rtpmap:0 PCMU/8000
a=rtpmap:8 PCMA/8000
a=rtpmap:101 telephone-event/8000/1
a=setup:actpass
a=ssrc:1426416515 cname:{6af8befe-6c10-4eaf-8f5b-df07ea6f7bed}
m=video 9 UDP/TLS/RTP/SAVPF 120 121 126 97
c=IN IP4 0.0.0.0
a=sendrecv
a=extmap:1 http://www.webrtc.org/experiments/rtp-hdrext/abs-send-time
a=extmap:2 urn:ietf:params:rtp-hdrext:toffset
a=extmap:3/sendonly urn:ietf:params:rtp-hdrext:sdes:rtp-stream-id
a=fmtp:126 profile-level-id=42e01f;level-asymmetry-allowed=1;packetization-mode=1
a=fmtp:97 profile-level-id=42e01f;level-asymmetry-allowed=1
a=fmtp:120 max-fs=12288;max-fr=60
a=fmtp:121 max-fs=12284;max-fr=63
a=ice-pwd:4caefce9e4e140554a3d521a2ed39d08
a=ice-ufrag:d8289e69
a=mid:sdparta_1
a=msid:{cb25209c-85a0-4206-b7fa-a60d9f86af44} {bda117ec-857c-456c-b944-e5d354f51ddc}
a=rid:f send
a=rid:h send
a=rid:i send
a=rid:q send pt=120,121;max-width=1280;max-height=720;max-fps=15
a=rtcp-fb:120 nack
a=rtcp-fb:120 nack pli
a=rtcp-fb:120 ccm fir
a=rtcp-fb:120 goog-remb
a=rtcp-fb:121 nack
a=rtcp-fb:121 nack pli
a=rtcp-fb:121 ccm fir
a=rtcp-fb:121 goog-remb
a=rtcp-fb:126 nack
a=rtcp-fb:126 nack pli
a=rtcp-fb:126 ccm fir
a=rtcp-fb:126 goog-remb
a=rtcp-fb:97 nack
a=rtcp-fb:97 nack pli
a=rtcp-fb:97 ccm fir
a=rtcp-fb:97 goog-remb
a=rtcp-mux
a=rtpmap:120 VP8/90000
a=rtpmap:121 VP9/90000
a=rtpmap:126 H264/90000
a=rtpmap:97 H264/90000
a=setup:actpass
a=simulcast:send f,~h;i;q
a=ssrc:2169237449 cname:{6af8befe-6c10-4eaf-8f5b-df07ea6f7bed}
a=ssrc:3812576694 cname:{6af8befe-6c10-4eaf-8f5b-df07ea6f7bed}
a=ssrc:3431483321 cname:{6af8befe-6c10-4eaf-8f5b-df07ea6f7bed}
";

        // A unit test from other parsers from Github
       public const string SDP7 = @"
v=0
o=- 18446744069414584320 18446462598732840960 IN IP4 127.0.0.1
s=-
t=0 0
a=msid-semantic:WMS local_stream_1
m=audio 2345 RTP/SAVPF 111 103 104
c=IN IP4 74.125.127.126
a=rtcp:2347 IN IP4 74.125.127.126
a=candidate:a0+B/1 1 udp 2130706432 192.168.1.5 1234 typ host generation 2
a=candidate:a0+B/1 2 udp 2130706432 192.168.1.5 1235 typ host generation 2
a=candidate:a0+B/2 1 udp 2130706432 ::1 1238 typ host generation 2
a=candidate:a0+B/2 2 udp 2130706432 ::1 1239 typ host generation 2
a=candidate:a0+B/3 1 udp 2130706432 74.125.127.126 2345 typ srflx raddr 192.168.1.5 rport 2346 generation 2
a=candidate:a0+B/3 2 udp 2130706432 74.125.127.126 2347 typ srflx raddr 192.168.1.5 rport 2348 generation 2
a=ice-ufrag:ufrag_voice
a=ice-pwd:0123456789012345678901
a=mid:audio_content_name
a=sendrecv
a=rtcp-mux
a=rtcp-rsize
a=rtpmap:111 opus/48000/2
a=rtpmap:103 ISAC/16000
a=rtpmap:104 ISAC/32000
a=ssrc:1 cname:stream_1_cname
a=ssrc:1 msid:local_stream_1 audio_track_id_1
a=ssrc:1 mslabel:local_stream_1
a=ssrc:1 label:audio_track_id_1
m=video 3457 RTP/SAVPF 120
c=IN IP4 74.125.224.39
a=rtcp:3456 IN IP4 74.125.224.39
a=candidate:a0+B/1 2 udp 2130706432 192.168.1.5 1236 typ host generation 2
a=candidate:a0+B/1 1 udp 2130706432 192.168.1.5 1237 typ host generation 2
a=candidate:a0+B/2 2 udp 2130706432 ::1 1240 typ host generation 2
a=candidate:a0+B/2 1 udp 2130706432 ::1 1241 typ host generation 2
a=candidate:a0+B/4 2 udp 2130706432 74.125.224.39 3456 typ relay generation 2
a=candidate:a0+B/4 1 udp 2130706432 74.125.224.39 3457 typ relay generation 2
a=ice-ufrag:ufrag_video
a=ice-pwd:0123456789012345678901
a=mid:video_content_name
a=sendrecv
a=rtpmap:120 VP8/90000
a=ssrc-group:FEC 2 3
a=ssrc:2 cname:stream_1_cname
a=ssrc:2 msid:local_stream_1 video_track_id_1
a=ssrc:2 mslabel:local_stream_1
a=ssrc:2 label:video_track_id_1
a=ssrc:3 cname:stream_1_cname
a=ssrc:3 msid:local_stream_1 video_track_id_1
a=ssrc:3 mslabel:local_stream_1
a=ssrc:3 label:video_track_id_1
";
        //    string sdp7_crypto1 = "a=crypto:1 AES_CM_128_HMAC_SHA1_80 inline:d0RmdmcmVCspeEc3QGZiNWpVLFJhQX1cfHAwJSoj|2^20|1:32";
        //    string sdp7_crypto2 = "a=crypto:1 AES_CM_128_HMAC_SHA1_32 inline:NzB4d1BINUAvLEw6UzF3WSJ+PSdFcGdUJShpX1Zj|2^20|1:32 dummy_session_params";
        // ==> TODO: implement crypto:   a=crypto:<tag> <cryto-suite> <key-params> [<session-params>]

        public const string SDP8 = @"
v=0
o=- 0 0 IN IP4 127.0.0.1
s=AgoraGateway
t=0 0
a=group:BUNDLE 0 1
a=msid-semantic: WMS
a=ice-lite
m=video 9 UDP/TLS/RTP/SAVPF 0
c=IN IP4 127.0.0.1
a=rtcp:9 IN IP4 0.0.0.0
a=sendonly
a=rtcp-mux
a=rtcp-rsize
a=mid:0
m=audio 9 UDP/TLS/RTP/SAVPF 0
c=IN IP4 127.0.0.1
a=rtcp:9 IN IP4 0.0.0.0
a=sendonly
a=rtcp-mux
a=rtcp-rsize
a=mid:1
";

    }
}
