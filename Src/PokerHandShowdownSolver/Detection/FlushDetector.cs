using System.Collections.Generic;
using System.Linq;

namespace PokerHandShowdownSolver.Detection
{
    public class FlushDetector : PokerHandDetector
    {
        public override PokerHand Result
        {
            get { return PokerHand.Flush; }
        }

        public override bool DoDetect(IEnumerable<PlayingCard> cards)
        {
            return
                cards
                    .GroupBy(card => card.Suit)
                    .Any(group => group.Count() == 5);
        }
    }
}