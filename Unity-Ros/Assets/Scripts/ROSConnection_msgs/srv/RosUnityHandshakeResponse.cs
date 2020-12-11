//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Collections.Generic;
using System.Text;
using RosMessageGeneration;

namespace RosMessageTypes.TcpEndpoint
{
    public class RosUnityHandshakeResponse : Message
    {
        public const string RosMessageName = "tcp_endpoint/RosUnityHandshake";

        public string ip;

        public RosUnityHandshakeResponse()
        {
            this.ip = "";
        }

        public RosUnityHandshakeResponse(string ip)
        {
            this.ip = ip;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(SerializeString(this.ip));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            var ipStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.ip = DeserializeString(data, offset, ipStringBytesLength);
            offset += ipStringBytesLength;

            return offset;
        }

    }
}
