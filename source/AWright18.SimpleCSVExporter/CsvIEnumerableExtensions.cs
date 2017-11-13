using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace AWright18.SimpleCSVExporter
{
    public static class CsvIEnumerableExtensions
    {
        public static void WriteCsvToStream<T>(this IEnumerable<T> objects, Stream stream, bool includeHeader = false)
        {
            var headerRow = typeof(T).ToCsvHeaderLine();
            var csvLines = objects.Select(o => o.ToCsvLine());
            
            using (var streamWriter = new StreamWriter(stream))
            {
                if(includeHeader)
                {
                    streamWriter.WriteLine(headerRow);
                }
                
                foreach (var line in csvLines)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}