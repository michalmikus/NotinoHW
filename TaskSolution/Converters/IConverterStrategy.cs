namespace TaskSolution
{
    public interface IConverterStrategy
    {
        public byte[] ConvertFile(string jsonContent);
    }
}