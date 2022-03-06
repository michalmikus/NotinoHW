using Microsoft.AspNetCore.Mvc;

namespace TaskSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterControler : ControllerBase
    {
        [HttpPost("convert/{format}")]
        public async Task<IActionResult> GetConvertedFile(IFormFile file, string format)
        {
            var documentLoader = new DocumentLoader();
            var documentConverter = new DocumentConverter();

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


