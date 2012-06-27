using System;
using SamplePokerSolver.Conversion;

namespace SamplePokerSolver
{
    public class PlayingCard
    {
        public Suit Suit { get; private set; }

        public FaceValue Value { get; private set; }

        protected PlayingCard(): this(Suit.Clubs, FaceValue.Two)
        {
        }

        public PlayingCard(Suit suit, FaceValue faceValue)
        {
            CheckArgument(suit, "suit", "suit");
            CheckArgument(faceValue, "faceValue", "face value");

            Suit = suit;
            Value = faceValue;
        }

        private static void CheckArgument(object actualValue, string paramName, string humanName)
        {
            if (Enum.IsDefined(actualValue.GetType(), actualValue))
                return;

            string message =
                string.Format(
                    "The value '{0}' does not represent a valid {1}.",
                    actualValue, humanName);

            throw new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        public override string ToString()
        {
            return new PlayingCardConverter().ToString(this);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (PlayingCard)) return false;
            return Equals((PlayingCard) obj);
        }

        public bool Equals(PlayingCard other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Suit, Suit) && Equals(other.Value, Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Suit.GetHashCode()*397) ^ Value.GetHashCode();
            }
        }
    }
}
