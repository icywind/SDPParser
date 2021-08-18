//
// Printer.cs
//
// Author:
//       Rick Cheng <rick@agora.io>
//
// Copyright (c) 2021 
//
// Permission is hereby granted, free in charge, to any person obtaining a copy
// in this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies in the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions in the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System.Linq;
using System.Collections.Generic;

namespace io.agora.sdp
{
    public class Printer
    {
        private string eol = Constants.CRLF;
        public string print(SessionDescription sessionDescription, string EOL)
        {
            string sdp = "";
            if (!string.IsNullOrEmpty(EOL))
            {
                this.eol = EOL;
            }

            sdp += this.printVersion(sessionDescription.Version.ToString());
            sdp += this.printOrigin(sessionDescription.Origin);
            sdp += this.printSessionName(sessionDescription.SessionName);
            sdp += this.printInformation(sessionDescription.SessionInformation);
            sdp += this.printUri(sessionDescription.Uri);
            sdp += this.printEmail(sessionDescription.EmailNumbers);
            sdp += this.printPhone(sessionDescription.PhoneNumbers);
            sdp += this.printConnection(sessionDescription.ConnectionData);
            sdp += this.printBandwidth(sessionDescription.BandWidths);
            sdp += this.printTimeFields(sessionDescription.TimeFields);
            sdp += this.printKey(sessionDescription.Key);
            sdp += this.printSessionAttributes(sessionDescription.Attributes as SessionAttributes);
            sdp += this.printMediaDescription(sessionDescription.MediaDescriptions);

            return sdp;
        }

        private string printVersion(string version)
        {
            return $"v ={version}{this.eol}";
        }

        private string printOrigin(Origin origin)
        {
            return $"o ={ origin.UserName} { origin.SessionId} { origin.SessionVersion} { origin.Nettype} { origin.AddrType} { origin.UnicastAddress}{ this.eol}";
        }

        private string printSessionName(string sessionName)
        {
            return sessionName != null ? $"s ={ sessionName}{ this.eol}" : "";
        }

        private string printInformation(string information)
        {
            return information != null ? $"i ={ information}{ this.eol}" : "";
        }

        private string printUri(string uri)
        {
            return uri != null ? $"u ={ uri}{ this.eol}" : "";
        }

        private string printEmail(IList<string> emails)
        {
            string result = "";
            foreach (string email in emails) {
                result += $"e ={ email}{ this.eol}";
            }
            return result;
        }

        private string printPhone(IList<string> phones)
        {
            string result = "";
            foreach (string phone in phones) {
                result += $"e ={ phone}{ this.eol}";
            }
            return result;
        }

        private string printConnection(ConnectionData connection)
        {
            return connection != null ?
                $"c ={ connection.Nettype} { connection.AddrType} { connection.ConnectionAddress}{ this.eol}" :
            "";
        }

        private string printBandwidth(IList<Bandwidth> bandwidths)
        {
            string result = "";
            foreach (Bandwidth bandwidth in bandwidths) {
                result += $"b ={ bandwidth.Type}:{ bandwidth.Value}{ this.eol}";
            }
            return result;
        }

        private string printTimeFields(IList<TimeField> timeFields)
        {
            string result = "";
            foreach (var timeField in timeFields) {
                result += $"t ={ timeField.Time.StartTime} { timeField.Time.StopTime}{ this.eol}";

                foreach (var repeatField in timeField.Repeats) {
                    result += $"r ={ repeatField.RepeatInterval } { string.Join(" ", repeatField.TypeTimes)}{ this.eol}";
                }

                if (timeField.timeZoneAdjustments != null)
                {
                    string zvalue = string.Join(" ", timeField.timeZoneAdjustments.Select((zone) => "" + zone.time + (zone.back ? "-" : "") + zone.typedTime));
                    result += $"z =";
                    result += $"z ={zvalue} {this.eol}";

                    result += this.eol;
                }
            }
            return result;
        }

        private string printKey(string key)
        {
            return key != null ? $"k ={ key}{ this.eol}" : "";
        }

        private string printAttributes(List<Attribute> attributes)
        {
            string result = "";
            foreach (var attribute in attributes) {
                result += $"a ={ attribute.attField}" + attribute.attValue != null ? attribute.attValue : "" + this.eol;
            }
            return result;
        }

        private string printMediaDescription(IList<MediaDescription> mediaDescriptions)
        {
            var result = "";
            foreach (var mediaDescription in mediaDescriptions) {
                result += this.printMedia(mediaDescription.Media);
                result += this.printInformation(mediaDescription.Information);
                result += this.printConnections(mediaDescription.Connections);
                result += this.printBandwidth(mediaDescription.Bandwidths);
                result += this.printKey(mediaDescription.Key);
                result += this.printMediaAttributes(mediaDescription);
            }
            return result;
        }

        private string printConnections(IList<ConnectionData> connections)
        {
            string result = "";
            foreach (var connection in connections) {
                result += this.printConnection(connection);
            }
            return result;
        }

        private string printMedia(Media media)
        {
            string protos = string.Join("/", media.protos);
            string fmts = string.Join(" ", media.fmts);
            return $"m =${ media.mediaType} ${ media.port} {protos} {fmts}${ this.eol}";
        }

        private string printSessionAttributes(SessionAttributes attributes)
        {
            var sessionAttributePrinter = new SessionAttributePrinter(this.eol);
            return sessionAttributePrinter.print(attributes);
        }

        private string printMediaAttributes(MediaDescription mediaDescription)
        {
            var mediaAttributePrinter = new MediaAttributePrinter(this.eol);
            return mediaAttributePrinter.print(mediaDescription);
        }
    }

    class AttributePrinter
    {
        protected string eol;

        public AttributePrinter(string eol)
        {
            this.eol = eol;
        }

        protected string printIceUfrag(string iceUfrag)
        {
            if (iceUfrag == null)
            {
                return "";
            }
            else
            {
                return $"a = ice - ufrag:{ iceUfrag}{ this.eol}";
            }
        }

        protected string printIcePwd(string icePwd)
        {
            if (icePwd == null)
            {
                return "";
            }
            else
            {
                return $"a = ice - pwd:${ icePwd}${ this.eol}";
            }
        }

        protected string printIceOptions(IList<string> iceOptions)
        {
            if (iceOptions == null)
            {
                return "";
            }

            string options = string.Join(Constants.SP.ToString(), iceOptions);

            return $"a = ice - options:{options}{this.eol}";
        }

        protected string printFingerprints(IList<FingerPrint> fingerprints)
        {
            var fing = fingerprints.Select((fingerprint) =>
                       $"a = fingerprint:{ fingerprint.hashFunction}{Constants.SP}{ fingerprint.fingerprint}");

            string prints = string.Join(this.eol, fing);
            if (fingerprints.Count > 0)
            {
                return prints + this.eol;
            }
            return "";
        }

        protected string printExtmap(IList<Extmap> extmaps)
        {
            var maps = extmaps.Select((extmap) =>
                  $"a = extmap:${ extmap.entry}" +
                      extmap.direction == null ? "" : $"/{ extmap.direction}" +
                      Constants.SP + extmap.extensionName +
                      extmap.extensionAttributes == null ? "" : Constants.SP + $"{ extmap.extensionAttributes}" +
                     this.eol
              );
            return string.Join("", maps);
        }

        protected string printSetup(string setup)
        {
            if (setup == null)
            {
                return "";
            }
            return $"a = setup:{setup}${ this.eol}";
        }

        protected string printUnrecognized(IList<Attribute> unrecognized)
        {
            var maps = unrecognized.Select(
                (attribute) =>
                  $"a ={ attribute.attField}" +
                attribute.attValue == null ? "" : $":{ attribute.attValue}" +
                $"{ this.eol}"
            );
            return string.Join("", maps);
        }
    }

    class SessionAttributePrinter : AttributePrinter
    {
        public SessionAttributePrinter(string eol) : base(eol)
        {
        }

        public string print(SessionAttributes attributes)
        {
            string lines = "";
            lines += this.printGroups(attributes.groups);
            lines += this.printMsidSemantic(attributes.msidSemantic);
            lines += this.printIceLite(attributes.iceLite);
            lines += this.printIceUfrag(attributes.iceUfrag);
            lines += this.printIcePwd(attributes.icePwd);
            lines += this.printIceOptions(attributes.iceOptions);
            lines += this.printFingerprints(attributes.fingerprints);
            lines += this.printSetup(attributes.setup);
            lines += this.printTlsId(attributes.tlsId);
            lines += this.printIdentity(attributes.identities);
            lines += this.printExtmap(attributes.extmaps);
            lines += this.printUnrecognized(attributes.unrecognized);

            return lines;
        }

        private string printGroups(IList<Group> groups)
        {
            string result = "";

            if (groups.Count > 0)
            {
                var strs = groups.Select(
                    (group) =>
                      $"a = group:{ group.semantic}" +
                     string.Join("", group.identificationTag.Select((item) => Constants.SP + item)) + // $"${ Constants.SP}${ item}")
                     this.eol
                );
                result += string.Join("", strs);
            }
            return result;
        }

        private string printIceLite(bool? iceLite)
        {
            if (iceLite == null)
            {
                return "";
            }
            else
            {
                return "a=ice-lite" + this.eol;
            }
        }

        private string printTlsId(string tlsId)
        {
            if (tlsId != null)
            {
                return $"a = tls - id:{ tlsId}{ this.eol}";
            }

            return "";
        }

        private string printIdentity(IList<Identity> identities)
        {
            if (identities.Count == 0)
            {
                return "";
            }

            var ids = identities.Select((identity) =>
                   $"a = identity:{ identity.assertionValue }" +
                   identity.extensions.Select((extension) =>
                      Constants.SP + extension.name + (
                          extension.value == null ? "" : $"={ extension.value}")
                    )
            );
            return (string.Join(this.eol, ids) + this.eol);
        }

        private string printMsidSemantic(MsidSemantic msidSemantic)
        {
            if (msidSemantic == null)
            {
                return "";
            }

            string result = $"a = msid - semantic:{ msidSemantic.semantic}";
            if (msidSemantic.applyForAll != null && msidSemantic.applyForAll == true)
            {
                result += $"{Constants.SP} *";
            }
            else if (msidSemantic.identifierList.Count > 0)
            {
                result += msidSemantic.identifierList.Select(
                  (identifier) => $"{ Constants.SP}{ identifier}"
              );
            }

            return result + this.eol;
        }
    }

    class MediaAttributePrinter : AttributePrinter
    {
        public MediaAttributePrinter(string eol) : base(eol) { }


        public string print(MediaDescription mediaDescription) {
            var attributes = mediaDescription.Attributes;
            string lines = "";

            lines += this.printRTCP(attributes.rtcp);

            lines += this.printIceUfrag(attributes.iceUfrag);

            lines += this.printIcePwd(attributes.icePwd);

            lines += this.printIceOptions(attributes.iceOptions);

            lines += this.printCandidates(attributes.candidates);

            lines += this.printRemoteCandidatesList(attributes.remoteCandidatesList);

            lines += this.printEndOfCandidates(attributes.endOfCandidates);

            lines += this.printFingerprints(attributes.fingerprints);

            lines += this.printSetup(attributes.setup);

            lines += this.printMid(attributes.mid);

            lines += this.printExtmap(attributes.extmaps);
            // if (
            //   mediaDescription.media.protos.indexOf("RTP") !== -1 ||
            //   mediaDescription.media.protos.indexOf("rtp") !== -1
            // ) {
            lines += this.printRTPRelated(attributes);
            // }

            lines += this.printPtime(attributes.ptime);

            lines += this.printMaxPtime(attributes.maxPtime);

            lines += this.printDirection(attributes.direction);

            lines += this.printSSRCGroups(attributes.ssrcGroups);

            lines += this.printSSRC(attributes.ssrcs);

            lines += this.printRTCPMux(attributes.rtcpMux);

            lines += this.printRTCPMuxOnly(attributes.rtcpMuxOnly);

            lines += this.printRTCPRsize(attributes.rtcpRsize);

            lines += this.printMSId(attributes.msids);

            lines += this.printImageattr(attributes.imageattr);

            lines += this.printRid(attributes.rids);

            lines += this.printSimulcast(attributes.simulcast);

            lines += this.printSCRPPort(attributes.sctpPort);

            lines += this.printMaxMessageSize(attributes.maxMessageSize);

            lines += this.printUnrecognized(attributes.unrecognized);

            return lines;
        }

        private string printCandidates(IList<Candidate> candidates)
        {
            string result = "";
            //return candidates
            //  .map(
            //    (candidate) =>
            //      $"a = candidate:${ candidate.foundation}${ Constants.SP}${
            //    candidate.componentId
            //      }${ Constants.SP}${ candidate.transport}${ Constants.SP}${ candidate.priority}${ Constants.SP}${
            //    candidate.connectionAddress
            //      }${ Constants.SP}${ candidate.port}${ Constants.SP}
            //typ${ Constants.SP}${ candidate.type}${
            //    candidate.relAddr ? $"${ Constants.SP}
            //    raddr${ Constants.SP}${ candidate.relAddr}" : ""
            //      }${
            //    candidate.relPort ? $"${ Constants.SP}
            //    rport${ Constants.SP}${ candidate.relPort}" : ""
            //      }${
            //    Object.keys(candidate.extension)
            //   .map((key) => $"${ Constants.SP}${ key}${ Constants.SP}${ candidate.extension[key]}")
            //        .join("")}${ this.eol}"
            //  )
            //  .join("");

            return result;
        }

        private string printRemoteCandidatesList(IList<RemoteCandidate> remoteCandidatesList)
        {
            var rl = remoteCandidatesList.Select(
                (remoteCandidates) =>
                  $"a = remote - candidates:{ string.Join(Constants.SP.ToString(), remoteCandidates) }{this.eol}"
              );
            return string.Join("", rl);
        }

        private string printEndOfCandidates(bool? endOfCandidates) {
            if (endOfCandidates == null) {
                return "";
            }

            return "a=end-of-candidates" + this.eol;
        }

        private string printRTPRelated(MediaAttributes attributes) {
            if (attributes.payloads == null) {
                return "";
            }
            var payloads = attributes.payloads;

            string lines = "";

            lines += string.Join("", attributes.rtcpFeedbackWildcards
              .Select((feedback) => this.printRTCPFeedback("*", feedback)));

            foreach (var payload in payloads) {
                lines += this.printRtpMap(payload.payloadType, payload.rtpMap);
                lines += this.printFmtp(payload.payloadType, payload.fmtp);
                lines += string.Join("", payload.rtcpFeedbacks
                  .Select((feedback) =>
                    this.printRTCPFeedback(payload.payloadType.ToString(), feedback)
                  ));
            }
            // (TS commented out)
            // foreach (var payloadType in Object.keys(payloads)) {
            //   lines += this.printRtpMap(payloadType, payloads[payloadType].rtpMap);
            //   lines += this.printFmtp(payloadType, payloads[payloadType].fmtp);
            //   lines += payloads[payloadType].rtcpFeedbacks
            //     .map((feedback) => this.printRTCPFeedback(payloadType, feedback))
            //     .join("");
            // }

            return lines;
        }

        private string printFmtp(int payloadType, Fmtp fmtp) {
            if (fmtp == null) {
                return "";
            }

            var keys = fmtp.parameters.Keys.ToArray();

            if (keys.Length == 1 && fmtp.parameters[keys[0]] == null) {
                //not xxx=yyy;aaa=bbb format
                return $"a=fmtp:${payloadType}" + Constants.SP + $"{keys[0]}{this.eol}";
            }

            var fparamkeys = fmtp.parameters.Keys.Select(
                        (key) => $"{key}={fmtp.parameters[key]}");

            string keysString = string.Join(";", fparamkeys);


            return $"a=fmtp:${payloadType}" + Constants.SP + keysString + this.eol;
        }

        private string printRtpMap(int payloadType, RTPMap rtpMap) {
            if (rtpMap == null) {
                return "";
            }

            return $"a=rtpmap:{payloadType}{Constants.SP}{rtpMap.encodingName}/{ rtpMap.clockRate }" +
                rtpMap.encodingParameters == null ? "" : $"/{rtpMap.encodingParameters}" + this.eol;
        }

        private string printRTCPFeedback(string payloadType, RTCPFeedback rtcpFeedback)
        {
            string result = $"a=rtcp-fb:{payloadType}{Constants.SP}";

            var feedback = rtcpFeedback;
            switch (feedback.type) {
                case "trr-int":
                    result += $"ttr-int{Constants.SP}{(feedback as TRRINTFeedback).interval}";
                    break;
                case "ack":
                case "nack":
                default:
                    var fb = feedback as RTCPACKCommmonFeedback;
                    result += fb.type;

                    if (fb.parameter != null) {
                        result += $"{Constants.SP}{fb.parameter}";

                        if (fb.additional != null) {
                            result += $"{Constants.SP}{fb.additional}";
                        }
                    }
                    break;
            }

            return result + this.eol;
        }

        private string printPtime(string ptime) {
            return ptime == null ? "" : $"a=ptime:{ptime}{this.eol}";
        }

        private string printMaxPtime(string maxPtime) {
            return maxPtime == null
              ? ""
              : $"a=maxptime:{maxPtime}{this.eol}";
        }

        private string printDirection(Direction? direction) {
            return direction == null ? "" : $"a={direction}{this.eol}";
        }

        private string printSSRC(IList<SSRC> ssrcs) {
            string result = string.Join("", ssrcs
                      .Select((ssrc) => string.Join("",
                        ssrc.attributes.Keys
                          .Select(
                            (attributeName) =>
                              $"a=ssrc:${ssrc.ssrcId}{Constants.SP}{attributeName}" +
                                ssrc.attributes[attributeName] == null
                                  ? "" : $":{ssrc.attributes[attributeName]}"
                              + this.eol
                          ))
                      ));

            return result;
        }

        private string printRTCPMux(bool? rtcpMux) {
            return rtcpMux == null ? "" : $"a=rtcp-mux{this.eol}";
        }

        private string printRTCPMuxOnly(bool? rtcpMuxOnly) {
            return rtcpMuxOnly == null
              ? ""
              : $"a=rtcp-mux-only{this.eol}";
        }

        private string printRTCPRsize(bool? rtcpRsize) {
            return rtcpRsize == null ? "" : $"a=rtcp-rsize{this.eol}";
        }

        private string printRTCP(RTCP rtcp) {
            if (rtcp == null) {
                return "";
            }

            string result = $"a=rtcp:${rtcp.port}";

            if (rtcp.netType != null) {
                result += $"$ {Constants.SP}{rtcp.netType}";
            }

            if (rtcp.addressType != null) {
                result += $"{Constants.SP}{rtcp.addressType}";
            }

            if (rtcp.address != null) {
                result += $"{Constants.SP}{rtcp.address}";
            }

            return result + this.eol;
        }

        private string printMSId(IList<MSID> msids) {
            string result = string.Join("", msids.Select(
                        (msid) =>
                          $"a=msid:{msid.id}" + msid.appdata == null ? "" : $"{Constants.SP}${msid.appdata}" +
                            this.eol
                      ));

            return result;
        }

        private string printImageattr(IList<string> imageattr) {
            return string.Join("", imageattr.Select((attr) => $"a=imageattr:{attr}{this.eol}"));
        }

        private string printRid(IList<RID> rids)
        {
            string str = "";
            var ridlist = rids.Select((rid) =>
            {
                string result = $"a=rid:{rid.Id}{Constants.SP}{rid.Direction}";

                if (rid.Payloads != null)
                {
                    result += $"{Constants.SP}pt=" + string.Join(",", rid.Payloads);
                }

                if (rid.Params.Count > 0)
                {
                    var paramstr = string.Join(":", rid.Params
                    .Select((param) =>
                    {
                        if (param.type == "depend")
                        {
                            return $"depend=" + string.Join(",", (param as RIDDependParam).rids);
                        }
                        else
                        {
                            return $"{param.type}=" + (param as RIDGenericParam).val;
                        }
                    }));

                    result += $"{Constants.SP}" + paramstr;
                }

                return result + this.eol;
            });
            str = string.Join("", ridlist);

            return str;
        }

        private string printSimulcast(string simulcast) {
            return simulcast == null
              ? ""
              : $"a=simulcast:{simulcast}{this.eol}";
        }

        private string printSCRPPort(string sctpPort) {
            return sctpPort == null
              ? ""
              : $"a=sctp-port:{sctpPort}{this.eol}";
        }

        private string printMaxMessageSize(string maxMessageSize) {
            return maxMessageSize == null
              ? ""
              : $"a=max-message-size:{maxMessageSize}";
        }

        private string printMid(string mid) {
            return mid == null ? "" : $"a=mid:{mid}{this.eol}";
        }

        private string printSSRCGroups(IList<SSRCGroup> ssrcGroups) {
            return string.Join("", ssrcGroups
              .Select(
                (ssrcGroup) =>
                  $"a=ssrc-group:{ssrcGroup.semantic}" +
                    string.Join("", ssrcGroup.ssrcIds.Select((id) => $"{Constants.SP}{id}")
                    + this.eol)
              ));
        }
    }
}
