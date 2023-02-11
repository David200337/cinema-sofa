using System;
using System.Text.Json;

namespace Cinema
{
    public class PlainTextExport : ExportType
    {
        public void Export<T>(T obj)
        {
            var file = "Order.txt";
            var jsonString = JsonSerializer.Serialize(obj);

            File.WriteAllText(file, jsonString);
        }
    }
}

