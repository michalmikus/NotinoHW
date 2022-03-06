using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Google.Protobuf;
using System.Xml;

namespace TaskSolution.Converter
{
    class ConvertToJSON : IConverterStrategy
    {
        public string FileName { get; set; }

        public ConvertToJSON(string fileName)
        {
            FileName = fileName;
        }

        public string ConvertFile()
        {
            DocumentHandler.SourceFile = FileName;

            var convertedDocument = DocumentHandler.GetJSON();

            DocumentHandler.WriteToFile(convertedDocument, ".json");

            return DocumentHandler.TargetFile;
        }
    }

    class ConvertToXML : IConverterStrategy
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public ConvertToXML(string fileName)
        {
            FileName = fileName;
        }


        public string ConvertFile()
        {
            DocumentHandler.SourceFile = FileName;

            var JSON = DocumentHandler.GetJSON();

            XmlDocument convertedDocument = JsonConvert.DeserializeXmlNode(JSON);

            DocumentHandler.WriteToFile(convertedDocument.OuterXml, ".xml");

            return DocumentHandler.TargetFile;
        }
    }

    class ConvertToProtobuf : IConverterStrategy
    {
        public string FileName { get; set; }

        public ConvertToProtobuf(string fileName)
        {
            FileName = fileName;
        }

        public string ConvertFile()
        {
            return "";
        }
    }

}