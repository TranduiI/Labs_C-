using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6B
{
    public class Deck
    {
        static private Random _rnd = new Random();
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    _cards.Add(new Card(Card.SUITS[i].ToString(), j));
                }
            }
        }

        public void SetCard(int id, Card card)
        {
            _cards[id] = card;
        }

        public Card GetCard(int id)
        {
            return _cards[id];
        }

        public void Shuffle()
        {
            List<Card> sorted = new List<Card>();
            int max = _cards.Count;
            while (max != 0)
            {
                int index = _rnd.Next(0, max - 1);
                sorted.Add(_cards[index]);
                _cards.RemoveAt(index);
                max--;
            }
            _cards = sorted;
        }
    }

}
