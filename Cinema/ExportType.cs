using System;
namespace Cinema
{
    public interface IExportType
    {
        public void Export<T>(T obj);
    }
}

