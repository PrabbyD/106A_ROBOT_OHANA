//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Collections.Generic;
using System.Text;
using RosMessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Geometry
{
    public class PolygonStamped : Message
    {
        public const string RosMessageName = "geometry_msgs/PolygonStamped";

        //  This represents a Polygon with reference coordinate frame and timestamp
        public Header header;
        public Polygon polygon;

        public PolygonStamped()
        {
            this.header = new Header();
            this.polygon = new Polygon();
        }

        public PolygonStamped(Header header, Polygon polygon)
        {
            this.header = header;
            this.polygon = polygon;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(polygon.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.polygon.Deserialize(data, offset);

            return offset;
        }

    }
}
