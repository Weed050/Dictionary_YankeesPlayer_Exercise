using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing
{
    public partial class Card
    {
        public override string ToString()
        {
            return Name;
        }
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public static bool DoesCardMatch(Card CardToCheck,Suits Suits)
        {
            if(CardToCheck.Suit == Suits)
                return true;
            else
                return false;

        }
        public static bool DoesCardMatch(Card CardToCheck,Values Value)
        {
            if (CardToCheck.Value == Value)
                return true;
            else
                return false;
        }
    }
    public enum Suits
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts,
    }
    public enum Values
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }
}
