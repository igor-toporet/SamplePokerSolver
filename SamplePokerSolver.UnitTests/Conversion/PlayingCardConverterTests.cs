using System;
using PokerHandShowdownSolver.Conversion;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Conversion
{
    public class PlayingCardConverterTests
    {
        private readonly IConverter<PlayingCard> converter = new PlayingCardConverter();

        [Theory]
        [InlineData(Suit.Clubs, FaceValue.Ace, "AC")]
        [InlineData(Suit.Diamonds, FaceValue.King, "KD")]
        [InlineData(Suit.Hearts, FaceValue.Ten, "10H")]
        [InlineData(Suit.Spades, FaceValue.Seven, "7S")]
        public void CanConvertToString(
            Suit suit, FaceValue faceValue, string expected)
        {
            // arrange
            var card = new PlayingCard(suit, faceValue);

            // act
            string cardAsString = converter.ToString(card);

            // assert
            Assert.Equal(expected, cardAsString);
        }

        [Theory]
        [InlineData(Suit.Clubs, FaceValue.Ace, "AC")]
        [InlineData(Suit.Diamonds, FaceValue.King, "KD")]
        [InlineData(Suit.Hearts, FaceValue.Ten, "10H")]
        [InlineData(Suit.Spades, FaceValue.Seven, "7S")]
        public void CanConvertFromString(
            Suit suit, FaceValue faceValue, string str)
        {
            // arrange
            var expectedCard = new PlayingCard(suit, faceValue);

            // act
            var actualCard = converter.FromString(str);

            // assert
            Assert.Equal(expectedCard, actualCard);
        }

        [Fact]
        public void ConversionFromStringThrowsArgumentNullExceptionWhenPassedNullInput()
        {
            // arrange
            string input = null;

            // act
            var exception = Record.Exception(
                () => converter.FromString(input));

            // assert
            var argumentNullException =
                Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("str", argumentNullException.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1234")]
        public void ConversionFromStringThrowsArgumentExceptionWhenPassedTooLongOrTooShortInput(
            string input)
        {
            // act
            var exception = Record.Exception(
                () => converter.FromString(input));

            // assert
            var argumentException =
                Assert.IsType<ArgumentException>(exception);
            Assert.Equal("str", argumentException.ParamName);
        }

        [Fact]
        public void ConversionFromStringThrowsArgumentExceptionWithInnerExceptionWhenInputRepresentsUnrecognizedSuit()
        {
            // arrange
            const string input = "10W";

            // act
            var exception = Record.Exception(
                () => converter.FromString(input));

            // assert
            Assert.IsType<FormatException>(exception);
            Assert.Equal("Unrecognized playing card '10W'", exception.Message);
            Assert.IsType<FormatException>(exception.InnerException);
            Assert.Equal("Unrecognized suit 'W'", exception.InnerException.Message);
        }

        [Fact]
        public void ConversionFromStringThrowsArgumentExceptionWithInnerExceptionWhenInputRepresentsUnrecognizedFaceValue()
        {
            // arrange
            const string input = "XD";

            // act
            var exception = Record.Exception(
                () => converter.FromString(input));

            // assert
            Assert.IsType<FormatException>(exception);
            Assert.Equal("Unrecognized playing card 'XD'", exception.Message);
            Assert.IsType<FormatException>(exception.InnerException);
            Assert.Equal("Unrecognized face value 'X'", exception.InnerException.Message);
        }
    }
}