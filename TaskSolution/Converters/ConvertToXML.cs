using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace TaskSolution.Converters
{
    public class ConvertToXML : IConverterStrategy
    {
        public byte[] ConvertFile(string jsonContent)
        {
            var convertedDocument = JsonConvert.DeserializeXmlNode(jsonContent)
                ?? throw new FormatException("Can't be converted into XML.");
               
            return Encoding.UTF8.GetBytes(convertedDocument.OuterXml);
        }
    }

}