using System;
namespace AWright18.SimpleCSVExporter.Tests
{
    public class TransformMeToCsv
    {
        public string FirstValue {get;set;} = "NormalString";
        public int SecondValue {get;set;} = 1;

        public string ThirdValue {get;set;} = "\"I have a comma, and spaces, and quotes\" \"";

        public TransformMeToCsv()
        {
            
        }
        public TransformMeToCsv(string firstValue, int secondValue, string thirdValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
            ThirdValue = thirdValue; 
        }
    }

}