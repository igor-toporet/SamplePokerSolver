namespace PokerHandShowdownSolver.Detection
{
    public class ThreeOfAKindDetector : FewOfAKindDetector
    {
        public ThreeOfAKindDetector() : base(3 /* numOfCardsOfSameKind */)
        {
        }

        public override PokerHand Result
        {
            get { return PokerHand.ThreeOfAKind; }
        }
    }
}