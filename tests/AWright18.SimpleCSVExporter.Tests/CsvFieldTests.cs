using System;
using Xunit;

namespace AWright18.SimpleCSVExporter.Tests
{
    public class CsvFieldTests
    {
        [Fact]
        public void FieldContainingADoubleQuoteIsSurroundedByDoubleQuotes()
        {
            var field = "\"ThisIsAValue\"";
            var csvField = "\"\"ThisIsAValue\"\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }


        [Fact]
        public void FieldContainingADoubleQuoteIsEscapesDoubleQuotesWithDoubleQuote()
        {
            var field = "\"ThisIsAValue\"";
            var csvField = "\"\"ThisIsAValue\"\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldContainingACommanIsSurrounedByDoubleQuotes()
        {
            var field = "Some,Comma,Delimited,Field";
            var csvField = "\"Some,Comma,Delimited,Field\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldContainingALineBreakIsSurrounedByDoubleQuotes()
        {
            var field = "Field\nWithA\nLineBreak";
            var csvField = "\"Field\nWithA\nLineBreak\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldContainingACarriageReturnIsSurrounedByDoubleQuotes()
        {
            var field = "Field\rWithA\rCarriageReturn";
            var csvField = "\"Field\rWithA\rCarriageReturn\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldContainingLeadingSpacesIsSurrounedByDoubleQuotes()
        {
            var field = "   FieldWithLeadingSpaces";
            var csvField = "\"   FieldWithLeadingSpaces\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }
        [Fact]
        public void FieldContainingTrailingSpaceIsSurrounedByDoubleQuotes()
        {
            var field = "FieldWithTrailingSpaces   ";
            var csvField = "\"FieldWithTrailingSpaces   \"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldContainingTrailingTabIsSurrounedByDoubleQuotes()
        {
            var field = "FieldWithTrailingSpaces\t";
            var csvField = "\"FieldWithTrailingSpaces\t\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldContainingLeadingTabIsSurrounedByDoubleQuotes()
        {
            var field = "\tFieldWithTrailingSpaces";
            var csvField = "\"\tFieldWithTrailingSpaces\"";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldsWithNoSpecialCharactersReturnTheSameValue()
        {
            var field = "NotSpecial";
            var csvField = "NotSpecial";
            field = field.ToCsvField();

            Assert.Equal(csvField, field);
        }

        [Fact]
        public void FieldsContainingQuotesWillBePrependedWithDoubleQuotes()
        {
            var field = "Contains\"Quote";
            var csvField = "\"Contains\"\"Quote\"";
            field = field.ToCsvField();

            Assert.Equal(csvField,field);
        }

        [Fact]
        public void CanConvertPropertyInfoToCsvField()
        {
            var testObject = new TransformMeToCsv();
            var expectedValue = "NormalString";
            var property = testObject.GetType().GetProperty("FirstValue");
            var output = property.ToCsvField(testObject);
            
            Assert.Equal(expectedValue, output);
        }

        [Fact]
        public void MixOfSpacesQuotesAndCommasInAField()        {
            var original = "\"I have a comma, and spaces, and quotes\" \"";
            var expected = "\"\"I have a comma, and spaces, and quotes\"\" \"\"";
            var output = original.ToCsvField();
            Assert.Equal(expected,output); 
        }       
    }
}
