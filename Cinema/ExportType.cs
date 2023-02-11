using System;
namespace Cinema
{
    public interface ExportType
    {
        public void Export<T>(T obj);
    }
}

