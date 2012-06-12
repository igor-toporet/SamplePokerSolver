using PokerHandShowdownSolver.Detection;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Detection
{
    public class HighCardDetectorTests
    {
        private readonly PokerHandDetector detector = new HighCardDetector();

        [Fact]
        public void ResultIsHighCard()
        {
            Assert.Equal(PokerHand.HighCard, detector.Result);
        }

        [Theory]
        [InlineData("Joe, 3H", true)]
        [InlineData("Bob", false)]
        public void CanDetectHighCard(string playerHandRepresentation, bool expectedDetectionResult)
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