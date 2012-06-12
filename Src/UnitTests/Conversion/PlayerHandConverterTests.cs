using System.Linq;
using PokerHandShowdownSolver.Conversion;
using Xunit;

namespace PokerHandShowdownSolver.UnitTests.Conversion
{
    public class PlayerHandConverterTests
    {
        private readonly IConverter<PlayerHand> converter = new PlayerHandConverter();

        private readonly PlayingCard jackH = new PlayingCard(Suit.Hearts, FaceValue.Jack);
        private readonly PlayingCard tenS = new PlayingCard(Suit.Spades, FaceValue.Ten);

        [Fact]
        public void CanConvertToString()
        {
            // arrange
            var playerHand = 
                new PlayerHand {Player = "John", Cards = new[] {jackH, tenS,}};

            // act
            string result = converter.ToString(playerHand);

            // assert
            Assert.Equal("John, JH, 10S", result);
        }

        [Fact]
        public void CanConvertToStringWithoutPlayerName()
        {
            // arrange
            var playerHand = new PlayerHand { Cards = new[] {jackH, tenS,}};

            // act
            string result = converter.ToString(playerHand);

            // assert
            Assert.Equal("<player not set>, JH, 10S", result);
        }

        [Fact]
        public void CanConvertToStringWithoutCards()
        {
            // arrange
            var playerHand = new PlayerHand {Player = "John"};

            // act
            string result = converter.ToString(playerHand);

            // assert
            Assert.Equal("John, <empty hand>", result);
        }

        [Fact]
        public void CanConvertFromString()
        {
            // arrange
            const string input = "John, JH, 10S";

            // act
            var hand = converter.FromString(input);

            // assert
            Assert.Equal("John", hand.Player);
            Assert.Equal(jackH, hand.Cards.First());
            Assert.Equal(tenS, hand.Cards.Last());
        }
    }
}