using System;
using System.Linq;
using System.Text;

namespace SamplePokerSolver.Conversion
{
    public class PlayerHandConverter : IConverter<PlayerHand>
    {
        public string ToString(PlayerHand hand)
        {
            var result = new StringBuilder();

            result.Append(
                string.IsNullOrEmpty(hand.Player)
                    ? "<player not set>"
                    : hand.Player);

            result.Append(", ");

            result.Append(
                hand.Cards
                    .Select(card => card.ToString())
                    .DefaultIfEmpty("<empty hand>")
                    .Aggregate((a, b) => a + ", " + b));

            return result.ToString();
        }

        public PlayerHand FromString(string str)
        {
            var result = new PlayerHand();

            if (!string.IsNullOrEmpty(str))
            {
                var parts = str.Split(
                    ", ".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0)
                {
                    result.Player = parts[0];

                    if (parts.Length > 1)
                    {
                        var cardConverter = new PlayingCardConverter();

                        result.Cards =
                            parts.Skip(1)
                                .Select(cardConverter.FromString);
                    }
                }
            }

            return result;
        }
    }
}
