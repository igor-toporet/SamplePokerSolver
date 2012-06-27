using System.Collections.Generic;

namespace SamplePokerSolver.Detection
{
    /// <summary>
    /// Base class for poker hands detection
    /// </summary>
    /// <remarks>
    /// Utilizing 'Chain Of Responsibility' pattern
    /// </remarks>
    public abstract class PokerHandDetector
    {
        /// <summary>
        /// Next poker hand detector in the chain of detection
        /// </summary>
        public PokerHandDetector Successor { get; set; }

        /// <summary>
        /// Detects particular poker hand or transfers responsibility
        /// to do so to it's successor
        /// </summary>
        /// <param name="cards">
        /// sequence of playing cards for particular poker hand detection
        /// </param>
        /// <returns>detected poker hand</returns>
        /// <remarks>
        /// Utilizing 'Template method' pattern.
        /// So general decision making template is set
        /// thus ancestors have to (in fact must to) implement
        /// only some of steps of it
        /// </remarks>
        public PokerHand Detect(IEnumerable<PlayingCard> cards)
        {
            if (DoDetect(cards))
            {
                return Result;
            }

            if (Successor == null)
            {
                return PokerHand.Unknown;
            }

            return Successor.Detect(cards);
        }

        /// <remarks>
        /// for testability reasons made public
        /// </remarks>
        public abstract PokerHand Result { get; }

        /// <remarks>
        /// for testability reasons made public
        /// </remarks>
        public abstract bool DoDetect(IEnumerable<PlayingCard> cards);
    }
}
