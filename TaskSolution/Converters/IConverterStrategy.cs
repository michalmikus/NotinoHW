namespace TaskSolution.Converters
{
    public interface IConverterStrategy
    {
        public byte[] ConvertFile(string jsonContent);
    }
}