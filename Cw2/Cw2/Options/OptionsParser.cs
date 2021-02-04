using System;
using System.IO;

namespace Cw2.Options
{
    public class OptionsParser
    {
        private readonly string[] args;

        public OptionsParser(string[] args)
        {
            this.args = args;
        }

        public Options Parse()
        {
            var inputFileName = ReadParam(0);
            
            ThrowIfPathIsInvalid(inputFileName);
            ThrowIfFileNotExists(inputFileName);

            return new Options(
                inputFileName ?? DefaultOptions.InputFileName
                , ReadParam(1) ?? DefaultOptions.OutputFileName
                , ReadParam(2) ?? DefaultOptions.Format
            );
        }

        private static void ThrowIfPathIsInvalid(string inputFileName)
        {
            if (string.IsNullOrWhiteSpace(inputFileName))
                return;
            
            if (inputFileName.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new ArgumentException("Plik nazwa nie istnieje");
        }

        private void ThrowIfFileNotExists(string inputFileName)
        {
            if (string.IsNullOrWhiteSpace(inputFileName))
                return;

            if (!File.Exists(inputFileName))
                throw new FileNotFoundException($"Plik: {inputFileName} nie istnieje");
        }

        private string ReadParam(int index)
        {
            return args.Length > index ? args[index] : null;
        }
    }
}