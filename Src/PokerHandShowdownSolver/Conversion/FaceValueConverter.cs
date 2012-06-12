using System;
using System.Linq;

namespace PokerHandShowdownSolver.Conversion
{
    public class FaceValueConverter : IConverter<FaceValue>
    {
        public string ToString(FaceValue value)
        {
            if (value < FaceValue.Jack)
            {
                return ((byte) value).ToString();
            }

            return value.ToString().Substring(0, 1);
        }

        public FaceValue FromString(string str)
        {
            byte value;
            if (byte.TryParse(str, out value)
                && 2 <= value && value <= 10)
            {
                return (FaceValue) value;
            }


            var facesAndAce = new[] {FaceValue.Ace, FaceValue.King, FaceValue.Queen, FaceValue.Jack};

            var valuesByFirstLetter =
                facesAndAce.ToDictionary(
                    faceValue => faceValue.ToString().Substring(0, 1),
                    faceValue => faceValue);

            if (valuesByFirstLetter.ContainsKey(str))
                return valuesByFirstLetter[str];

            throw new FormatException(
                string.Format("Unrecognized face value '{0}'", str));
        }
    }
}