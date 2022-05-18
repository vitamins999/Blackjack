using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class DrawPile
    {
        Queue<Card> drawPile = new Queue<Card>();

        public DrawPile(int numberOfDecks)
        {
            List<Card> unshuffledPile = new List<Card>();

            for(int i = 0; i < numberOfDecks; i++)
            {
                Deck deck = new Deck();
                unshuffledPile.AddRange(deck.GetAllCardsInDeck());
            }

            Shuffle(unshuffledPile);
        }

        private void Shuffle(List<Card> unshuffledPile)
        {
            Random rand = new Random();
            int totalCards = unshuffledPile.Count;

            while (totalCards > 0)
            {
                int index = rand.Next(totalCards);

                drawPile.Enqueue(unshuffledPile[index]);
                unshuffledPile.RemoveAt(index);

                totalCards--;
            }
        }

        public Card DrawCard()
        {
            return drawPile.Dequeue();
        }
    }
}
