namespace PokerHandShowdownSolver
{
    public enum PokerHand : byte
    {
        Flush = 128,

        ThreeOfAKind = 64,

        TwoOfAKind = 32,

        HighCard = 16,

        Unknown = 0
    }
}