using PokerHandShowdownSolver.Detection;
using Xunit;
using Xunit.Extensions;

namespace PokerHandShowdownSolver.UnitTests.Detection
{
    public class FlushDetectorTests
    {
        private readonly PokerHandDetector detector = new FlushDetector();

        [Fact]
        public void ResultIsFlash()
        {
            Assert.Equal(PokerHand.Flush, detector.Result);
        }

        [Theory]
        [InlineData("Joe, 3H, 4H, 5H, 6H, 8H", true)]
        [InlineData("Bob, 3C, 3D, 3S, 8C, 10D", false)]
        [InlineData("Sally, AC, 10C, 5C, 2S, 2C", false)]
        public void CanDetectFlush(string playerHandRepresentation, bool expectedDetectionResult)
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