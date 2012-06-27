using System;
using System.Linq;

namespace SamplePokerSolver.Conversion
{
    public class PlayingCardConverter : IConverter<PlayingCard>
    {
        public string ToString(PlayingCard card)
        {
            string suit = new SuitConverter().ToString(card.Suit);
            string faceValue = new FaceValueConverter().ToString(card.Value);

            return faceValue + suit;
        }

        public PlayingCard FromString(string str)
        {
            if (str == null)
                throw new ArgumentNullException("str" /* paramName */);

            if (str.Length < 2 || 3 < str.Length)
                throw new ArgumentException(
                    "In order to represent a playing card string must be a 2 or 3 characters long",
                    "str" /* paramName */);

            try
            {
                string lastCharacter = str.Last().ToString();
                var suit = new SuitConverter().FromString(lastCharacter);

                string firstOneOrTwoCharacters = str.Substring(0, str.Length - 1);
                var faceValue = new FaceValueConverter().FromString(firstOneOrTwoCharacters);

                return new PlayingCard(suit, faceValue);
            }
            catch (Exception e)
            {
                throw new FormatException(
                    string.Format("Unrecognized playing card '{0}'", str),
                    e /* innerException */);
            }
        }
    }
}
