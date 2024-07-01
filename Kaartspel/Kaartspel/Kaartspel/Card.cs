using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaartspel
{
    public class Card
    {
        public cardTypes cardType;
        public int cardIndex;
        private int cardValue;
        public CardInfo cardInfo;

        public Dictionary<int, string> cardReference = new Dictionary<int, string>()
        {
            [0] = "1",
            [1] = "2",
            [2] = "3",
            [3] = "4",
            [4] = "6",
            [5] = "7",
            [6] = "8",
            [7] = "9",
            [8] = "10",
            [9] = "J",
            [10] = "Q",
            [11] = "K",
            [12] = "Ace",
        };

        public Card(cardTypes _cardType, int _cardIndex)
        {
            this.cardType = _cardType;
            this.cardIndex = _cardIndex;
            this.cardInfo = new CardInfo(_cardType);
        }

        public string DisplayCard()
        {
            return $"[{this.cardInfo.color}]{this.cardType} {cardReference[this.cardIndex]}[/]";
        }
    }
    
}

