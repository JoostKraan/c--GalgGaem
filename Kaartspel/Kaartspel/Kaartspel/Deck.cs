using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Kaartspel
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        private Random RNG = new Random();
        public int points;
        public Card currentCard;

        public Deck()
        {
            foreach (var cardType in Enum.GetValues<cardTypes>())
            {
                for (int i = 0; i < 13; i++)
                {
                    Card newCard = new Card(cardType, i);
                    cards.Add(newCard);
                }
            }
        }

        public Card PullRandomCard()
        {
            return cards[RNG.Next(0, cards.Count)];
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }
        public void SetPoints(int points)
        {
            this.points = points;
        }
        public int GetPoints() { return points; }
    }
  
}


