using System;
namespace AWright18.SimpleCSVExporter
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvFieldAttribute : Attribute
    {
        public CsvFieldAttribute(string name = null)
        {
              Name = name;
        }
        public string Name {get;set;}
        
    }
}