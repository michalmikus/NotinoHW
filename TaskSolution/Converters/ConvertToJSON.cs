using System.Text;

namespace TaskSolution.Converters
{
    public class ConvertToJSON : IConverterStrategy
    {
        public byte[] ConvertFile(string jsonContent)
        {
            return Encoding.UTF8.GetBytes(jsonContent);
        }
    }

}