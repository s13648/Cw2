using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using Cw2.Data;
using Cw2.Options;

namespace Cw2.Utils
{
    public static class Serializer
    {
        public static void Serialize(University university, Options.Options options)
        {
            switch (options.Format)
            {
                case "xml":
                     XmlSerialize(university);
                    break;
                case "json":
                    JsonSerialize(university);
                    break;
                default: throw new ArgumentException("Nieznany format danych");
            }
        }

        private static void JsonSerialize(University university)
        {
            var jsonString = JsonSerializer.Serialize(university);
            File.WriteAllText("data.json", jsonString);
        }

        private static void XmlSerialize(University university)
        {
            var writer = new FileStream(@"data.xml", FileMode.Create);
            var serializer = new XmlSerializer(typeof(University));
            serializer.Serialize(writer, university);
        }
    }
}