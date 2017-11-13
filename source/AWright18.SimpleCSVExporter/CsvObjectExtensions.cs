using System;
using System.Linq;

namespace AWright18.SimpleCSVExporter
{
    public static class CsvObjectExtensions
    {
        public static string ToCsvLine(this object o)
        {
            var csvFields =
                o.GetType().GetProperties()
                .Select(p => p.ToCsvField(o));
            var csvLine = String.Join(",", csvFields);
            return csvLine;
        }

        public static string ToCsvHeaderLine(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var propertyNames = type.GetProperties().Select(p => p.Name);

            var fields = propertyNames.Select(n => n.ToCsvField());

            var headerRow = String.Join(",", fields);

            return headerRow;
        }
    }


}