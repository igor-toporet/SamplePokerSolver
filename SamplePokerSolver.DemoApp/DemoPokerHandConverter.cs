using System;
using System.Text;
using PokerHandShowdownSolver.Conversion;

namespace PokerHandShowdownSolver.DemoApp
{
    internal class DemoPokerHandConverter : IConverter<PokerHand>
    {
        public string ToString(PokerHand hand)
        {
            //
            // can't rely on hand.ToString() because it might be
            // already containing some special conversion/representation
            // that will broke my logic
            //
            // hence =>
            //
            var handName = Enum.GetName(typeof (PokerHand), hand);

            var result = new StringBuilder(handName);

            for (int i = handName.Length - 1; i >= 0; i--)
            {
                var letter = handName[i].ToString();

                if (letter == letter.ToUpper())
                {
                    result.Insert(i, " ");
                }
            }

            return result.ToString();
        }

        public PokerHand FromString(string str)
        {
            throw new NotImplementedException();
        }
    }
}