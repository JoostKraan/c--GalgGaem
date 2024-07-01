using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaartspel
{
    public class CardInfo
    {
        public string type;
        public string color;
        public Dictionary<cardTypes, string> emojiDictionary = new Dictionary<cardTypes, string>()
        {
            [cardTypes.spades] = "\u2660",
            [cardTypes.diamonds] = "\u2665",
            [cardTypes.hearts] = "\u2666",
            [cardTypes.clubs] = "\u2663",
        };

        public CardInfo(cardTypes cardType)
        {
            if ((cardType == cardTypes.spades) || (cardType == cardTypes.clubs))
            {
                this.color = "grey23";
            }
            else
            {
                this.color = "maroon";
            }

            type = emojiDictionary[cardType];
        }
    }
    public enum cardTypes
    {
        clubs,
        diamonds,
        hearts,
        spades
    }
}
