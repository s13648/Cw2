namespace Cw2.Options
{
    public record Options
    {
        public Options(string inputFileName, string outputFileName, string format)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            Format = format;
        }

        public string InputFileName { get; } 
        public string OutputFileName { get; }
        public string Format { get; }
    }
}