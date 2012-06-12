using System;
using PokerHandShowdownSolver.Conversion;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Conversion
{
    public class FaceValueConverterTests
    {
        // arrange
        private readonly IConverter<FaceValue> converter = new FaceValueConverter();


        [Theory]
        [InlineData(FaceValue.Ace, "A")]
        [InlineData(FaceValue.King, "K")]
        [InlineData(FaceValue.Queen, "Q")]
        [InlineData(FaceValue.Jack, "J")]
        [InlineData(FaceValue.Ten, "10")]
        [InlineData(FaceValue.Nine, "9")]
        [InlineData(FaceValue.Eight, "8")]
        [InlineData(FaceValue.Seven, "7")]
        [InlineData(FaceValue.Six, "6")]
        [InlineData(FaceValue.Five, "5")]
        [InlineData(FaceValue.Four, "4")]
        [InlineData(FaceValue.Three, "3")]
        [InlineData(FaceValue.Two, "2")]
        public void CanConvertToString(FaceValue faceValue, string expected)
        {
            // act
            string actual = converter.ToString(faceValue);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("A", FaceValue.Ace)]
        [InlineData("K", FaceValue.King)]
        [InlineData("Q", FaceValue.Queen)]
        [InlineData("J", FaceValue.Jack)]
        [InlineData("10", FaceValue.Ten)]
        [InlineData("9", FaceValue.Nine)]
        [InlineData("8", FaceValue.Eight)]
        [InlineData("7", FaceValue.Seven)]
        [InlineData("6", FaceValue.Six)]
        [InlineData("5", FaceValue.Five)]
        [InlineData("4", FaceValue.Four)]
        [InlineData("3", FaceValue.Three)]
        [InlineData("2", FaceValue.Two)]
        public void CanConvertFromString(string str, FaceValue expected)
        {
            // act
            FaceValue actual = converter.FromString(str);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Z")]
        [InlineData("1")]
        [InlineData("16")]
        [InlineData("-20")]
        public void ConversionFromStringThrowsExceptionForWrongInputs(string input)
        {
            // arrange
            string expectedMessage =
                "Unrecognized face value '" + input + "'";

            // act
            var exception = Record.Exception(
                () => converter.FromString(input));

            // assert
            Assert.IsType<FormatException>(exception);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}