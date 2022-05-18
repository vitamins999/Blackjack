using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Deck
    {
        private List<Card> allCards = new List<Card>();

        public Deck()
        {
            allCards.AddRange(GenerateSuite("Hearts"));
            allCards.AddRange(GenerateSuite("Diamonds"));
            allCards.AddRange(GenerateSuite("Spades"));
            allCards.AddRange(GenerateSuite("Clubs"));
        }

        private List<Card> GenerateSuite(string suiteName)
        {
            List<Card> suite = new List<Card>();

            suite.Add(new Card("Two", suiteName, 2));
            suite.Add(new Card("Three", suiteName, 3));
            suite.Add(new Card("Four", suiteName, 4));
            suite.Add(new Card("Five", suiteName, 5));
            suite.Add(new Card("Six", suiteName, 6));
            suite.Add(new Card("Seven", suiteName, 7));
            suite.Add(new Card("Eight", suiteName, 8));
            suite.Add(new Card("Nine", suiteName, 9));
            suite.Add(new Card("Ten", suiteName, 10));
            suite.Add(new Card("Jack", suiteName, 10));
            suite.Add(new Card("Queen", suiteName,10));
            suite.Add(new Card("King", suiteName, 10));
            suite.Add(new Card("Ace", suiteName, 11));

            return suite;
        }

        public List<Card> GetAllCardsInDeck()
        {
            return allCards;
        }
    }
}
