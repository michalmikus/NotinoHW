using Microsoft.AspNetCore.Mvc;
using TaskSolution.Document;
using TaskSolution.Documents;

namespace TaskSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterControler : ControllerBase
    {
        private readonly DocumentLoader documentLoader;
        private readonly DocumentConverter documentConverter;

        public ConverterControler(DocumentLoader documentLoader, DocumentConverter documentConverter)
        {
            this.documentLoader = documentLoader;
            this.documentConverter = documentConverter;
        }
        [HttpPost("convert/{format}")]
        public async Task<IActionResult> GetConvertedFile(IFormFile file, string format)
        {

            try
            {
                var jsonContent = await documentLoader.LoadJson(file);

                var document = documentConverter.Convert(format, jsonContent);

                return File(document.Content, document.ContentType);
            }
            catch (FormatException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}


