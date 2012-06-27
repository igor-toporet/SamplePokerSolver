using System;
using System.Linq;
using Xunit;

namespace SamplePokerSolver.UnitTests
{
    public class PackTests
    {
        [Fact]
        public void CanCreatePack()
        {
            // arrange

            // act
            var pack = new Pack();

            // assert
            Assert.Equal(52, pack.Count());
        }

        [Fact]
        public void CanShuffle()
        {
            // arrange
            var pack = new Pack(false /* shuffle */);

            // act
            pack.Shuffle();

            // assert
            Assert.NotEqual(Pack.Etalon, pack);
        }

        [Fact]
        public void CanDeal()
        {
            // arrange
            var pack = new Pack();

            // act
            var hand = pack.Deal(5);

            // assert
            Assert.Equal(5, hand.Count());
            Assert.Equal(47, pack.Count());
        }

        [Fact]
        public void DealThrowsExceptionIfThereAreNotEnoughCards()
        {
            // arrange
            const string expectedMessage =
                "Unable to deal 60 cards. There are 52 cards only in the pack.";

            // act
            var exception = Record.Exception(
                () => new Pack().Deal(60));

            // assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
