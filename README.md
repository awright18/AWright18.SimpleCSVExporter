# AWright18.SimpleCSVExporter
A Simple CSV Exporter for .NET 

## Convert IEnumerable To CSV 
```
    public class ThingToConvertToCsv
    {
        [CsvField(Name="First Value")]
        public string FirstValue {get;set;}
        public int SecondValue {get;set;}
        public string ThirdValue {get;set;}
    }

    public static void Main(string[] args)
    {
        var thingsToConvert = new [] { new ThingToConvertToCsv(), new ThingToConvertToCsv()}
        //Convert to IEnumerable<string> lines
        IEnumerable<string> csvLines =  thingsToConvert.ToCsvLines();

        //Write IEnumerable<T> to a stream
        thingsToConvert.WriteToStream(File.Open("somefile.csv", FileMode.Append));
    }
```