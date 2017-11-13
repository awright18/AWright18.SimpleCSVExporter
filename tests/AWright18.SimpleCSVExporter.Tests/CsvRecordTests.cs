using Xunit;
using System.IO;
namespace AWright18.SimpleCSVExporter.Tests
{
    public class CsvRecordTests
    {
        [Fact]
        public void RecordCanBeConvertedToCSV()
        {
            var testObject = new TransformMeToCsv();
            var expectedString = "NormalString,1,\"\"I have a comma, and spaces, and quotes\"\" \"\"";
            var outputString = testObject.ToCsvLine();            
            Assert.Equal(expectedString,outputString);
        }   

        [Fact]
        public void CanExportIEnumerableToCsvStream()
        {
            var testObjects = new []{new TransformMeToCsv(), new TransformMeToCsv()};
            var fs = File.Open("outputFile.csv",FileMode.Append);
            testObjects.WriteCsvToStream(fs, true);            
        }
    }
}