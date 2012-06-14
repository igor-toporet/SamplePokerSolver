using System;
using PokerHandShowdownSolver.Conversion;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Conversion
{
    public class SuitConverterTests
    {
        // arrange
        private readonly IConverter<Suit> converter = new SuitConverter();


        [Theory]
        [InlineData(Suit.Clubs, "C")]
        [InlineData(Suit.Diamonds, "D")]
        [InlineData(Suit.Hearts, "H")]
        [InlineData(Suit.Spades, "S")]
        public void CanConvertToString(Suit suit, string expected)
        {
            // act
            string actual = converter.ToString(suit);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("C", Suit.Clubs)]
        [InlineData("D", Suit.Diamonds)]
        [InlineData("H", Suit.Hearts)]
        [InlineData("S", Suit.Spades)]
        public void CanConvertFromString(string str, Suit expected)
        {
            // act
            var suit = converter.FromString(str);

            // assert
            Assert.Equal(expected, suit);
        }

        [Theory]
        [InlineData("Q")]
        [InlineData("?")]
        public void ConversionFromStringThrowsExceptionForWrongInputs(string input)
        {
            // arrange
            string expectedMessage =
                "Unrecognized suit '" + input + "'";

            // act
            var exception = Record.Exception(
                () => converter.FromString(input));

            // assert
            Assert.IsType<FormatException>(exception);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}