//
// AttributeTypes.cs
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

    public class Group
    {
        public string semantic { get; set; }
        public IList<string> identificationTag { get; set; }
    }

    public class FingerPrint
    {
        public string hashFunction { get; set; }
        public string fingerprint { get; set; }
    }

    public enum Setup // "active" | "passive" | "actpass" | "holdconn";
    {
        active,
        passive,
        actpass,
        holdconn
    }

    public class Extension
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Identity
    {
        public string assertionValue { get; set; }
        public IList<Extension> extensions { get; set; }
    }

    public class Extmap
    {
        public int entry;
        public string extensionName;
        public string direction;
        public string extensionAttributes;
    }

    public class Candidate
    {
        public string foundation { get; set; }
        public string componentId { get; set; }
        public string transport { get; set; }
        public string priority { get; set; }
        public string connectionAddress { get; set; }
        public string port { get; set; }
        public string type { get; set; }
        public string relAddr { get; set; }
        public string relPort { get; set; }
        public IDictionary<string, string> extension { get; set; }
    }

    public class RemoteCandidate
    {
        public string componentId { get; set; }
        public string connectionAddress { get; set; }
        public string port { get; set; }
    }

    public class RTPMap
    {
        // payloadType: string;
        public string encodingName;
        public string clockRate;
        public int encodingParameters;
    }

    public class Fmtp
    {
        // format: string;
        public IDictionary<string, string> parameters;
    }

    public enum Direction
    {
        sendrecv,
        sendonly,
        recvonly,
        inactive
    };

    public class SSRC
    {
        long ssrcId;
        IDictionary<string, string> attributes;
    }

    public class SSRCGroup
    {
        string semantic;
        IList<long> ssrcIds;
    }

    public enum RTCPFeedback
    {
        ACKFeedback,
        NACKFeedback,
        TRRINTFeedback,
        OtherFeedback
    };


    public class ACKFeedback
    {
        public string type { get; set; }
        public string parameter { get; set; }// "rpsi" | "app" | string;
        public string additional { get; set; }

        public ACKFeedback()
        {
            type = "ack";
        }
    }

    public class NACKFeedback
    {
        public string type { get; set; }
        public string parameter { get; set; }//"pli" | "sli" | "rpsi" | "app" | string
        public string additional { get; set; }

        public NACKFeedback()
        {
            type = "nack";
        }
    }

    public class TRRINTFeedback
    {
        public string type { get; set; }
        public string interval { get; set; }
        public TRRINTFeedback()
        {
            type = "trr-int";
        }
    }

    public class OtherFeedback
    {
        public string type;
        public string parameter { get; set; }//"app" | string
        public string additional { get; set; }
    }

    public class RTCP
    {
        public string port { get; set; }
        public string netType { get; set; }
        public string addressType { get; set; }
        public string address { get; set; }
    }

    public class MSID
    {
        public string id { get; set; }
        public string appdata { get; set; }
    }

    #region RID classes

    public abstract class RIDParam
    {
        public abstract string type { get; set; }
    }

    public class RIDWidthParam
    {
        public string type { get; set; } = "max-width";
        public string val { get; set; }
    }

    public class RIDHeightParam
    {
        public string type { get; set; } = "height-width";
        public string val { get; set; }
    }

    public class RIDFpsParam
    {
        public string type { get; set; } = "max-fps";
        public string val { get; set; }
    }

    public class RIDFsParam
    {
        public string type { get; set; } = "max-fs";
        public string val { get; set; }
    }

    public class RIDBrParam
    {
        public string type { get; set; } = "max-br";
        public string val { get; set; }
    }

    public class RIDPpsParam
    {
        public string type { get; set; } = "max-pps";
        public string val { get; set; }
    }

    public class RIDBppParam
    {
        public string type { get; set; } = "max-bpp";
        public string val { get; set; }
    }

    public class RIDDependParam
    {
        public string type { get; set; } = "depend";
        public IList<string> rids { get; set; }
    }

    public class RIDOtherParam
    {
        public string type { get; set; }
        public string val { get; set; }
    }

    public class RID
    {
        public string Id { get; set; }
        public string Direction { get; set; } // "send" | "recv";
        public IList<string> Payloads { get; set; }
        public IList<RIDParam> Params { get; set; }
    }
    #endregion



    public class MsidSemantic
    {
        public string semantic { get; set; }
        public bool? applyForAll { get; set; }
        public IList<string> identifierList { get; set; }
    }

    //    public class ExtmapEntry = Record<string, Extmap>;

    public class PayloadAttribute
    {
        public RTPMap rtpMap { get; set; }
        public Fmtp fmtp { get; set; }
        public IList<RTCPFeedback> rtcpFeedbacks { get; set; }
        public int payloadType { get; set; }
    }

    //  public class PayloadMap = Record<string, PayloadAttribute>;

    public class SessionAttributes
    {
        public IList<Group> groups { get; set; }
        public bool? iceLite { get; set; }
        public string iceUfrag { get; set; }
        public string icePwd { get; set; }
        public IList<string> iceOptions { get; set; }
        public IList<FingerPrint> fingerprints { get; set; }
        public Setup setup { get; set; }
        public string tlsId { get; set; }
        public IList<Identity> identities { get; set; }
        public IList<Extmap> extmaps { get; set; }
        public IList<Attribute> unrecognized { get; set; }
        public MsidSemantic msidSemantic { get; set; }
    }

    public class MediaAttributes
    {
        public string mid { get; set; }
        public string iceUfrag { get; set; }
        public string icePwd { get; set; }
        public string iceOptions { get; set; }
        public IList<Candidate> candidates { get; set; }
        public IList<RemoteCandidate> remoteCandidatesList { get; set; }
        public bool? endOfCandidates { get; set; }
        public IList<FingerPrint> fingerprints { get; set; }
        //public string // rtpMaps: RTPMap[];
        //public string // fmtp: Fmtp[];
        public string ptime { get; set; }
        public string maxPtime { get; set; }
        public Direction direction { get; set; }
        public IList<SSRC> ssrcs { get; set; }
        public IList<Extmap> extmaps { get; set; }
        //public string // rtcpFeedbacks: RTCPFeedback[];
        public bool? rtcpMux { get; set; }
        public bool? rtcpMuxOnly { get; set; }
        public bool? rtcpRsize { get; set; }
        public RTCP rtcp { get; set; }
        public IList<MSID> msids { get; set; }
        public IList<string> imageattr { get; set; }
        public IList<RID> rids { get; set; }
        public string simulcast { get; set; }
        public string sctpPort { get; set; }
        public string maxMessageSize { get; set; }
        public IList<Attribute> unrecognized { get; set; }
        public Setup setup { get; set; }
        public IList<PayloadAttribute> payloads { get; set; }
        public IList<RTCPFeedback> rtcpFeedbackWildcards { get; set; }
        public IList<SSRCGroup> ssrcGroups { get; set; }
    }
}
