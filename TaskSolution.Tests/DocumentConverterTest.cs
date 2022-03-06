using Newtonsoft.Json;
using TaskSolution.Converters;
using TaskSolution.Documents;
using Xunit;
using System.Text;
using System;

namespace TaskSolution.Tests
{
    public class DocumentConverterTest
    {
        [Fact]
        public void DocumentConverter_JsonToXML()
        {
            var correctXML = Encoding.UTF8.GetBytes("<document><Text>Toto je faktura za mesiac marec.</Text><Title>Faktura</Title></document>");

            var testData = new
            {
                document = new
                {
                    Text = "Toto je faktura za mesiac marec.",
                    Title = "Faktura"
                }
            };

            var testJSON = JsonConvert.SerializeObject(testData);


            var documentConverter = new ConvertToXML();

            var convertedXML = documentConverter.ConvertFile(testJSON);

            Assert.Equal(correctXML, convertedXML);
        }

        [Fact]
        public void DocumentConverter_InvalidOutputFormat_ThrowsFormatException()
        {
            var testData = new
            {
                document = new
                {
                    Text = "Toto je faktura za mesiac marec.",
                    Title = "Faktura"
                }
            };

            var testJSON = JsonConvert.SerializeObject(testData);

            var unsupprtedFormat = "yaml";


            var documentConverter = new DocumentConverter();

            var exception = Assert.Throws<FormatException>(() => documentConverter.Convert(unsupprtedFormat,testJSON));

            Assert.Equal("Unsupported output format.", exception.Message);

        }
    }
}