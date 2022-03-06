using System.Text;

namespace TaskSolution.Converter
{
    public class ConvertToJSON : IConverterStrategy
    {   
        public byte[] ConvertFile(string jsonContent)
        {
            return Encoding.UTF8.GetBytes(jsonContent);
        }
    }

}