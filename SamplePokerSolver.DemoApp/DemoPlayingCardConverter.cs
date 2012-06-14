using System;
using PokerHandShowdownSolver.Conversion;

namespace PokerHandShowdownSolver.DemoApp
{
    internal class DemoPlayingCardConverter : IConverter<PlayingCard>
    {
        public string ToString(PlayingCard card)
        {
            var suitConverter = new DemoSuitConverter();
            var faceValueConverter = new FaceValueConverter();

            return
                faceValueConverter.ToString(card.Value).PadLeft(2)
                + suitConverter.ToString(card.Suit).PadRight(2);
        }

        public PlayingCard FromString(string str)
        {
            throw new NotImplementedException();
        }
    }
}