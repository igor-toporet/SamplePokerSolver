using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandShowdownSolver
{
    public class Pack : IEnumerable<PlayingCard>
    {
        public static readonly Pack Etalon = new Pack(false /* don't shuffle */);

        private readonly List<PlayingCard> _cards;

        public Pack() : this(true /* shuffle */)
        {
        }

        public Pack(bool shuffle)
        {
            var allSuits = Enum.GetValues(typeof (Suit)).Cast<Suit>();
            var allFaceValues = Enum.GetValues(typeof (FaceValue)).Cast<FaceValue>();

            var allPossibleCombinations =
                from
                    suit in allSuits
                from
                    value in allFaceValues
                select
                    new PlayingCard(suit, value);
            
            _cards = allPossibleCombinations.ToList();

            if (shuffle) 
                Shuffle();
        }

        public void Shuffle()
        {
            var tmp = new PlayingCard[_cards.Count];
            _cards.CopyTo(tmp);

            _cards.Clear();

            var rnd = new Random();
            _cards.AddRange(tmp.OrderBy(r => rnd.Next()));
        }

        public IEnumerator<PlayingCard> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Deals an number of cards from pack
        /// </summary>
        /// <param name="numOfCards">number of cards to be dealt</param>
        /// <returns>
        /// sequence of cards containing requested number of cards
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// if pack does not contains requested number of cards
        /// </exception>
        public IEnumerable<PlayingCard> Deal(int numOfCards)
        {
            Check(numOfCards);
            
            var deal = _cards
                .Take(numOfCards)
                // deep copy
                .Select(c => new PlayingCard(c.Suit, c.Value));

            _cards.RemoveRange(0, numOfCards);

            return deal.ToArray();
        }

        private void Check(int numOfCards)
        {
            if (numOfCards > _cards.Count)
                throw
                    new InvalidOperationException(
                        string.Format(
                            "Unable to deal {0} cards. There are {1} cards only in the pack.",
                            numOfCards, _cards.Count));
        }
    }
}