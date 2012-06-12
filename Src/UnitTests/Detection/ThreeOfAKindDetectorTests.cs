using PokerHandShowdownSolver.Detection;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Detection
{
    public class ThreeOfAKindDetectorTests
    {
        private readonly PokerHandDetector detector = new ThreeOfAKindDetector();

        [Fact]
        public void ResultIsThreeOfAKind()
        {
            Assert.Equal(PokerHand.ThreeOfAKind, detector.Result);
        }

        [Theory]
        [InlineData("Joe, 3H, 3S, 5H, 6S, 3D", true)]
        [InlineData("Bob, 3C, AD, JS, 8C, JD", false)]
        [InlineData("Sally, 5S, 10C, 5C, 2S, 5H", true)]
        public void CanDetectThreeOfAKind(string playerHandRepresentation, bool expectedDetectionResult)
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