using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;
        public Game(string playerName, IEnumerable<string> opponentsNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string opponent in opponentsNames)
                players.Add(new Player(opponent, random, textBoxOnForm));
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }
        private void Deal()
        {
            stock.Shuffle();
            foreach (Player player in players)
            {
                for (int i = 0; i < 5; i++)
                    player.TakeCard(stock.Deal());
                player.PullOutBooks();
            }
        }
        public bool PlayOneRound(int selectedPlayerCard)
        {
            if (selectedPlayerCard == null)
                return false;
            // false - gra nie jest skończona, true - koniec gry (brak kart w decku)
            else
            {
                Card card = players[0].Peek(selectedPlayerCard);
                players[0].AskForACard(players, 0, stock, card.Value);

                for (int player = 1; player < players.Count; player++)
                    players[player].AskForACard(players, player, stock);
                // inni gracze pytają o karty

                players[0].SortHand();
                // weź od innych karty odpowiadające wskazanej karcie
                foreach (var player in players)
                {
                    PullOutBooks(player);
                    if (player.CardCount == 0)
                        for (int i = 0; i < 5; i++)
                        {
                            player.TakeCard(stock.Deal());
                            if (stock.Count == 0)
                            {
                                textBoxOnForm.Text = "Na kupce nie ma już kart. Gra skończona!";
                                return true;

                            }
                        }
                    //jak nie ma kart to mu daj z kupki, jak się skończą na kupce to koniec gry
                }
                return false;
            }

        }
        public bool PullOutBooks(Player player)
        {
            foreach (var player1 in players)
            {
                IEnumerable<Values> values = player.PullOutBooks();
                foreach (Values value in values)
                    books.Add(value, player);
            }
            if (player.CardCount == 0)
                return true;
            //wyciąga zestawy kart, jeżeli zostały jakieś karty graczowi to zwróć false, inaczej true
            else
                return false;
        }
        public string DescribeBooks()
        {
            string strToReturn = "";
            foreach (var book in books)
            {
                strToReturn += book.Value.Name + " ma grupę " + book.Key + ", \n ";
            }
            return strToReturn;
        }
        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach (var player in books.Values)
            {
                winners.Add(player.Name, 0);
                foreach (Values value in books.Keys)
                {
                    if (books[value] == player)
                        winners[player.Name] += 1;
                }
            }
            var winnersList = winners.ToList();
            winnersList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            //sortowanie do sprawdzenia

            if (winnersList[1].Value == winnersList[2].Value)
                return winnersList[0].Key + " i " + winnersList[1].Key + " mają " + winnersList[0].Value + " grup.";
            else
                return winnersList[0].Key + ": " + winnersList[0].Value + " grupy.";

        }
        public IEnumerable<string> GetPlayerHands() => players[0].GetCardNames();
        public string DescribePlayerHands()
        {
            string description = "";

        }
    }
}
