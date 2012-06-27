namespace SamplePokerSolver.Detection
{
    public class TwoOfAKindDetector : FewOfAKindDetector
    {
        public TwoOfAKindDetector() : base(2 /*numOfCardsOfSameKind */)
        {
        }

        public override PokerHand Result
        {
            get { return PokerHand.TwoOfAKind; }
        }
    }
}
