using Microsoft.AspNetCore.Mvc;
using TaskSolution.Converter;

namespace TaskSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterControler : ControllerBase
    {   
        [HttpPost("convert/{format}")]
        public FileContentResult GetConvertedFile(IFormFile file, string format)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, file.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }

            switch (format)
            {
                case "json":
                    var convertToJSON = new ConvertToJSON(file.FileName);
                    return File(System.IO.File.ReadAllBytes(convertToJSON.ConvertFile()), "application/json");

                case "xml":
                    var convertToXML = new ConvertToXML(file.FileName);
                    return File(System.IO.File.ReadAllBytes(convertToXML.ConvertFile()), "text/xml");

            }

            return null;
        }
    }
}

 