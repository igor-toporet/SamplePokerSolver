using PokerHandShowdownSolver.Detection;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Detection
{
    public class TwoOfAKindDetectorTests
    {
        private readonly PokerHandDetector detector = new TwoOfAKindDetector();

        [Fact]
        public void ResultIsTwoOfAKind()
        {
            Assert.Equal(PokerHand.TwoOfAKind, detector.Result);
        }

        [Theory]
        [InlineData("Joe, 3H, 4S, 4D, 6S", true)]
        [InlineData("Bob, 3C, 7D, 9S, AH", false)]
        [InlineData("Sally, AC, 10C, 5C, AS, 2D", true)]
        public void CanDetectTwoOfAKind(string playerHandRepresentation, bool expectedDetectionResult)
        {
            // arrange
            var playerHand = playerHandRepresentation.CreateFromString();

            // act
            bool detected = detector.DoDetect(playerHand.Cards);

            // assert
            Assert.Equal(expectedDetectionResult, detected);
        }
    }
}