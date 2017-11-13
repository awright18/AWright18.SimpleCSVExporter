using System;
using System.Linq;
using System.Reflection;
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
            var fields =  type.GetProperties()
                .Select(p => p.GetHeaderFieldName())
                .Select(p => p.ToCsvField());                
            var headerRow = String.Join(",", fields);
            return headerRow;
        }

        public static string GetHeaderFieldName(this PropertyInfo property)
        {
            var csvField = property.GetCustomAttributes<CsvFieldAttribute>().FirstOrDefault();
            return csvField?.Name ?? property.Name;            
        }
    }


}