using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace AWright18.SimpleCSVExporter
{
    public static class CsvIEnumerableExtensions
    {
        public static IEnumerable<string> ToCsvLines<T>(this IEnumerable<T> objects, bool includeHeader = false)
        {
            var headerRow = new [] {typeof(T).ToCsvHeaderLine()};
            var csvLines = objects.Select(o => o.ToCsvLine());
            var lines = includeHeader ? headerRow.Concat(csvLines) : csvLines;
            return lines;
        }

        public static void WriteCsvToStream<T>(this IEnumerable<T> objects, Stream stream, bool includeHeader = false)
        {
            var csvLines = objects.ToCsvLines(includeHeader);
            using (var streamWriter = new StreamWriter(stream))
            {
                foreach (var line in csvLines)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}