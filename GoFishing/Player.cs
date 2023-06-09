﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards = new Deck(new Card[] { });
            textBoxOnForm.Text = name + " dołączył do gry. \n";
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 0; i < 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).Value == value)
                        howMany++;
                if (howMany == 4)
                {
                    books.Add(value);
                    for (int card = cards.Count - 1; card >= 0; card--)
                        cards.Deal(card);
                }
            }
            return books;
        }
        public Values GetRandomValue()
        => cards.Peek(random.Next(cards.Count)).Value;
        // card with random value
        // => (Values)this.random.Next(1, 14);\

        //{
        //    Card card = cards.Peek(random.Next(cards.Count));
        //    return card.Value;
        //}
        
        public Deck DoYouHaveAny(Values value)
        {
            Deck deckToReturn = cards.PullOutValues(value);
            textBoxOnForm.Text +=
                Name + " ma " + deckToReturn.Count + " " +
                Card.Plural(value, deckToReturn.Count) + ". \n";
            return deckToReturn;
        }
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            if (stock.Count > 0)
                AskForACard(players, myIndex, stock, (Values)random.Next(1, 14));
                
        }
            //=> AskForACard(players, myIndex, stock, (Values)random.Next(1, 14));
        //do sprawdzenia czy działa

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            if (stock.Count > 0)
            {

            //do sprawdzenia
            textBoxOnForm.Text = Name + " pyta, czy ktoś ma " + Card.Plural(value,1) + ". \n";
            Deck deckToAdd;
            Deck cardsAdded = new Deck(new Card[] { });
            for (int i = 0; i < players.Count; i++)
            {
                if (i == myIndex)
                    continue;

                deckToAdd = players[i].DoYouHaveAny(value);
                while (deckToAdd.Count > 0)
                    cardsAdded.Add(deckToAdd.Deal());
            }
            if (cardsAdded.Count == 0)
            {
                cards.Add(stock.Deal());
                textBoxOnForm.Text = Name + " wziął kartę z kupki. \n";
            }
            else
                for (int i = 0; i < cardsAdded.Count -1; i++)
                    cards.Add(cardsAdded.Deal(i));
            // dodaje karty do kart gracza
            }
        }
        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }

        
    }
}
