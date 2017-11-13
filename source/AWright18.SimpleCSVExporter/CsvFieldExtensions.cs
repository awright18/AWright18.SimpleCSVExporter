using System;
using System.Linq;
using System.Reflection;
namespace AWright18.SimpleCSVExporter
{
    public static class CsvFieldExtensions
    {
        public static string ToCsvField(this PropertyInfo property, object sourceObject)
        {
            var propertyValue = property.GetValue(sourceObject);
            var csvField = propertyValue.ToCsvField();
            return csvField;
        }

        public static string ToCsvField(this object field)
        {
            var fieldAsString = field.ToString();

            var _field = new [] {fieldAsString};

            var csvField = _field 
                .Select(f => f.PrependExistingInternalDoubleQuoteWithDoubleQuote())
                .Where(f => f.ContainsDoubleQuotes() 
                    || f.ContainsAComma() 
                    || f.ContainsALineBreak()
                    || f.ContainsACarriageReturn()
                    || f.StartsWithASpace()
                    || f.EndsWithASpace()
                    || f.StartsWithATab()
                    || f.EndsWithATab())                
                .Select(f => f.SurroundWithDoubleQuotes());
            return csvField.FirstOrDefault() ?? fieldAsString;
        }

        public static bool ContainsDoubleQuotes(this string field)
        {
            return field.Contains('"');
        }

        public static string PrependExistingInternalDoubleQuoteWithDoubleQuote(this string field)
        {
            var updatedField = new [] {field};

            var newField = updatedField
            .Where( f => f.ContainsDoubleQuotes() && f.Length > 2)
            .Select(f => f.Substring(1,field.Length - 2))
            .Where(f => f.ContainsDoubleQuotes())
            .Select(f => f.Replace("\"", "\"\""))
            .Select(f => field.Substring(0,1) + f + field.Substring(field.Length -1,1))
            .FirstOrDefault();
            
            return newField ?? field;        
        }

        public static string SurroundWithDoubleQuotes(this string field)
        {
            return $"\"{field}\"";
        }

        public static bool ContainsAComma(this string field)
        {
            return field.Contains(',');
        }

        public static bool ContainsALineBreak(this string field)
        {
            return field.Contains('\n');
        }

        public static bool ContainsACarriageReturn(this string field)
        {
            return field.Contains('\r');
        }

        public static bool StartsWithASpace(this string field)
        {
            return field.StartsWith(" ");
        }

        public static bool EndsWithASpace(this string field)
        {
            return field.EndsWith(" ");
        }

        public static bool StartsWithATab(this string field)
        {
            return field.StartsWith("\t");
        }

        public static bool EndsWithATab(this string field)
        {
            return field.EndsWith("\t");
        }
    }
}
