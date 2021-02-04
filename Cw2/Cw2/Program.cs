using System;
using Cw2.Data;
using Cw2.Options;
using Cw2.Utils;

namespace Cw2
{
    
    internal static class Program
    {
        //.\export_xyz "C:\Users\Jan\Desktop\csvData.csv"
        //"C:\Users\Jan\Desktop\wynik.xml" xml

        static void Main(string[] args)
        {
            try
            {
                var options = new OptionsParser(args).Parse();
                var dataReader = new DataReader(options);
                var enumerable = dataReader.GetRecords();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                Logger.LogException(e);
            }
        }
    }
}