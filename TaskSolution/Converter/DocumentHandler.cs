using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Google.Protobuf;
using System.Xml;

namespace TaskSolution
{
    public class DocumentHandler
    {

        public static string TargetFile { get; set; }
        public static string SourceFile { get; set; }


        public static string GetInput()
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, SourceFile);

            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                string input = reader.ReadToEnd();
                reader.Close();

                return input;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetJSON()
        {
            var fileType = SourceFile.Split(".")[1];
            
            switch(fileType)
            {
                case "xml":
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(DocumentHandler.GetInput());

                    return JsonConvert.SerializeXmlNode(xmlDocument);

                case "json":
                    return DocumentHandler.GetInput();
            }
            return null;
        }

        public static void WriteToFile(string convertedDocument, string type)
        {
            TargetFile = Path.Combine(Environment.CurrentDirectory, SourceFile.Split(".")[0] + type);
            var targetStream = File.Open(TargetFile, FileMode.Create, FileAccess.Write);

            var streamWriter = new StreamWriter(targetStream);
            streamWriter.Write(convertedDocument);
            streamWriter.Close();
        }
    }
}