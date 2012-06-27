using System;
using Xunit;
using Xunit.Extensions;

namespace SamplePokerSolver.UnitTests
{
    public class PlayingCardTests
    {
        private static readonly string NewLine = Environment.NewLine;

        [Theory]
        [InlineData(0, FaceValue.Nine)]
        [InlineData(5, FaceValue.Queen)]
        public void CanRestrictPlayingCardCreationToExistingSuitsOnly(
            int intSuit, FaceValue faceValue)
        {
            // arrange
            var suit = (Suit)intSuit;
            string expectedMessage =
                "The value '" + suit + "' does not represent a valid suit." + NewLine
                + "Parameter name: suit" + NewLine
                + "Actual value was " + suit + ".";

            // act
            var exception = Record.Exception(
                () => new PlayingCard(suit, faceValue));

            // assert
            var argOutOfRangeExc =
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(suit, argOutOfRangeExc.ActualValue);
            Assert.Equal("suit", argOutOfRangeExc.ParamName);
            Assert.Equal(expectedMessage, argOutOfRangeExc.Message);
        }

        [Theory]
        [InlineData(Suit.Diamonds, 0)]
        [InlineData(Suit.Hearts, 200)]
        public void CanRestrictPlayingCardCreationToExistingFaceValuesOnly(
            Suit suit, int intFaceValue)
        {
            // arrange
            var faceValue = (FaceValue)intFaceValue;
            string expectedMessage =
                "The value '" + faceValue + "' does not represent a valid face value." + NewLine
                + "Parameter name: faceValue" + NewLine
                + "Actual value was " + faceValue + ".";

            // act
            var exception = Record.Exception(
                () => new PlayingCard(suit, faceValue));

            // assert
            var argOutOfRangeExc =
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal(faceValue, argOutOfRangeExc.ActualValue);
            Assert.Equal("faceValue", argOutOfRangeExc.ParamName);
            Assert.Equal(expectedMessage, argOutOfRangeExc.Message);
        }
    }
}
