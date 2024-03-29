using Newtonsoft.Json;
using System.Xml;

namespace TaskSolution.Document
{
    public class DocumentLoader
    {
        public async Task<string> LoadJson(IFormFile file)
        {
            var content = await ReadRequestAsync(file);

            switch (file.ContentType)
            {
                case "text/xml":
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(content);

                    return JsonConvert.SerializeXmlNode(xmlDocument);

                case "application/json":
                    return content;
                default:
                    throw new FormatException("Input format unsupported.");
            }
        }

        private async Task<string> ReadRequestAsync(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                using (var reader = new StreamReader(fileStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}