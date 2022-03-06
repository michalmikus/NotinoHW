using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace TaskSolution.Converter
{
    public class ConvertToXML : IConverterStrategy
    {
        public byte[] ConvertFile(string jsonContent)
        {
            var convertedDocument = JsonConvert.DeserializeXmlNode(jsonContent);
            return Encoding.UTF8.GetBytes(convertedDocument.OuterXml);
        }
    }

}