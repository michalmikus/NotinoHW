using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TaskSolution.Document;
using Xunit;

namespace TaskSolution.Tests
{
    public class FormFileMock : IFormFile, IDisposable
    {
        private readonly MemoryStream stream;

        public FormFileMock(string content, string contentType)
        {
            stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            ContentType = contentType;
        }


        public string ContentDisposition => throw new System.NotImplementedException();

        public IHeaderDictionary Headers => throw new System.NotImplementedException();

        public long Length => stream.Length;

        public string Name => throw new System.NotImplementedException();

        public string FileName => throw new System.NotImplementedException();

        public string ContentType { get; }

        public void CopyTo(Stream target)
        {
            throw new System.NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public Stream OpenReadStream()
        {
            return stream;
        }
    }
    public class DocumentLoaderTest
    {
        [Fact]
        public async void DocumentLoader_XmlToJson()
        {
            string content = "<document><Text>Toto je faktura za mesiac marec.</Text><Title>Faktura</Title></document>";
            string contentType = "text/xml";

            var file = new FormFileMock(content, contentType);


            var testData = new
            {
                document = new
                {
                    Text = "Toto je faktura za mesiac marec.",
                    Title = "Faktura"
                }
            };

            string correctJSON = JsonConvert.SerializeObject(testData);

           

            var documentLoader = new DocumentLoader();

            var loadedJSON = await documentLoader.LoadJson(file);


            Assert.Equal(correctJSON, loadedJSON);
        }
        
        [Fact]
        public async void DocumentLoader_InvalidInputFormat_ThrowsFormatException()
        {
            string content = "<document><Text>Toto je faktura za mesiac marec.</Text><Title>Faktura</Title></document>";
            string contentType = "wrong/format";

            var file = new FormFileMock(content, contentType);

            var documentLoader = new DocumentLoader();

            var exception = await Assert.ThrowsAsync<FormatException>(async () => await documentLoader.LoadJson(file));

            Assert.Equal("Input format unsupported.", exception.Message);
        }
    }
}