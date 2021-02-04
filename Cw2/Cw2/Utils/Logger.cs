using System;
using System.IO;

namespace Cw2.Utils
{
    public static class Logger
    {
        private const string LogFilePath = "log.txt";

        public static void LogException(Exception exception)
        {
            File.AppendAllText(LogFilePath,"\n________________\n");
            File.AppendAllText(LogFilePath,exception.Message);
        }

        public static void LogStudent(string[] student)
        {
            File.AppendAllText(LogFilePath,"\n________________\n");
            File.AppendAllText(LogFilePath,string.Join(",",student));
        }
    }
}