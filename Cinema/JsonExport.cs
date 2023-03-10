using System;
using System.Text.Json;

namespace Cinema
{
    public class JsonExport : IExportType
    {
        public void Export<T>(T obj)
        {
            var file = "Order.json";
            var jsonString = JsonSerializer.Serialize(obj);

            File.WriteAllText(file, jsonString);
        }
    }
}

