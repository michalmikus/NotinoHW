using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Google.Protobuf;

namespace TaskSolution.Converters
{
    public class ConvertToProtobuf : IConverterStrategy
    {
        public byte[] ConvertFile(string jsonContent)
        {
            return new byte[] { };
        }
    }

}