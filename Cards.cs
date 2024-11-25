using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6B
{
    public class Card
    {
        static public string SUITS = "CDHS";
        private string _suit;
        private int _rank;

        private Card()
        {
            _suit = "";
            _rank = 0;
        }

        public Card(string suit, int rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public override string ToString()
        {
            string rank;
            switch (_rank)
            {
                case 10:
                    rank = "J";
                    break;
                case 11:
                    rank = "Q";
                    break;
                case 12:
                    rank = "K";
                    break;
                case 0:
                    rank = "A";
                    break;
                default:
                    rank = (_rank + 1).ToString();
                    break;

            }
            return $"{rank}{_suit}";
        }

        public string Suit
        {
            get
            {
                return _suit;
            }
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
        }
    }

}
