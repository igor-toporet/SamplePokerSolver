using System.Linq;
using Xunit;

namespace SamplePokerSolver.UnitTests
{
    public class ShowdownSolverTests
    {
        [Fact]
        public void CanGetSingleWinner()
        {
            // arrange
             const string sampleData = @"
Joe, 3H, 4H, 5H, 6H, 8H
Bob, 3C, 3D, 3S, 8C, 10D
Sally, AC, 10C, 5C, 2S, 2C";
            var playerHands = sampleData.CreateFromStringLines();
            
            // act
            var winners = ShowdownSolver.GetWinners(playerHands);

            // assert
            Assert.Equal("Joe", winners.Single());
        }

        [Fact]
        public void CanGetMultipleWinners()
        {
            // arrange
             const string sampleData = @"
Joe, 3H, 4S, 5D, 6C, 8H
Bob, 3C, 3D, 3S, 8D, 10D
Sally, AC, 10C, AH, 2S, AD";
            var playerHands = sampleData.CreateFromStringLines();
            
            // act
            var winners = ShowdownSolver.GetWinners(playerHands).ToList();

            // assert
            Assert.Equal(2, winners.Count);
            Assert.Equal("Bob", winners.First());
            Assert.Equal("Sally", winners.Last());
        }
    }
}
