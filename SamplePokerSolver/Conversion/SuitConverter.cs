using System;
using System.Linq;

namespace PokerHandShowdownSolver.Conversion
{
    public class SuitConverter : IConverter<Suit>
    {
        public string ToString(Suit value)
        {
            return value.ToString().Substring(0, 1);
        }

        public Suit FromString(string str)
        {
            var allSuits = Enum.GetValues(typeof(Suit)).Cast<Suit>();

            var valuesByFirstLetter =
                allSuits.ToDictionary(
                    suit => suit.ToString().Substring(0, 1),
                    suit => suit);

            if (valuesByFirstLetter.ContainsKey(str))
                return valuesByFirstLetter[str];

            throw new FormatException(
                string.Format("Unrecognized suit '{0}'", str));
        }
    }
}