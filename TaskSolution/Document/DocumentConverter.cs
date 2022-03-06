using TaskSolution.Converter;

namespace TaskSolution.Controllers
{
    public record Document(byte[] Content, string ContentType);

    public class DocumentConverter
    {
        public Document Convert(string format, string jsonContent)
        {
            switch (format)
            {
                case "json":
                    var convertToJSON = new ConvertToJSON();
                    return new Document(convertToJSON.ConvertFile(jsonContent), "application/json");

                case "xml":
                    var convertToXML = new ConvertToXML();
                    return new Document(convertToXML.ConvertFile(jsonContent), "text/xml");
                default:
                    throw new FormatException("Unsupported output format.");

            }
        }
    }
}


