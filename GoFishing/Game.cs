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
            for (int i = 0; i < 5; i++)
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
            foreach (Player player in players)
                player.PullOutBooks();

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
                    //PullOutBooks(player);
                    //if (player.CardCount == 0)
                    //    for (int i = 0; i < 5; i++)
                    //    {
                    //        player.TakeCard(stock.Deal());
                    //        if (stock.Count == 0)
                    //        {
                    //            textBoxOnForm.Text = "Na kupce nie ma już kart. Gra skończona!";
                    //            return true;

                    //        }
                    //    }
                    if (PullOutBooks(player))
                    {
                        textBoxOnForm.Text += player.Name + " ciągnie karty \n\r";
                        int carD = 1;
                        while (carD <= 5 && stock.Count > 0)
                        {
                            player.TakeCard(stock.Deal());
                            carD++;
                        }
                    }
                    players[0].SortHand();
                    if (stock.Count == 0)
                    {
                        textBoxOnForm.Text = "Gra skończona, na kupce nie ma żadnych kart. \r\n";
                        return true;
                    }
                    //jak nie ma kart to mu daj z kupki, jak się skończą na kupce to koniec gry
                }
                return false;
            }

        }
        public bool PullOutBooks(Player player)
        {
            IEnumerable<Values> values = player.PullOutBooks();
            foreach (var player1 in players)
            {
                foreach (Values value in values)
                    books.Add(value, player);
            }
            if (player.CardCount == 0)
                return true;
            //wyciąga zestawy kart, jeżeli zostały jakieś karty graczowi to zwróć false, inaczej true
            return false;
        }
        public string DescribeBooks()
        {
            string strToReturn = "";
            foreach (var book in books)
                strToReturn += book.Value.Name + " ma grupę " + Card.Plural(book.Key, 0) + ", \r\n ";

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

            // wersja książki


            //Dictionary<string, int> winners2 = new Dictionary<string, int>();
            //foreach (var value in books.Keys)
            //{
            //    string name = books[value].Name;
            //    if (winners2.ContainsKey(name))
            //        winners2[name]++;
            //    else
            //        winners2.Add(name, 1);
            //}
            //int mostBooks = 0;
            //foreach (var name in winners2.Keys)
            //    if (winners2[name] > mostBooks)
            //        mostBooks = winners2[name];

            //bool tie = false;
            //string winnerList = "";
            //foreach (var name in winners2.Keys)
            //{
            //    if (winners2[name] == mostBooks)
            //        if (!String.IsNullOrEmpty(winnerList))
            //        {
            //            winnerList += " i ";
            //            tie = true;
            //        }
            //    winnerList += name;
            //}
            //winnerList += ": " + mostBooks + " grupy ";
            //if (tie)
            //    return "Remis pomiędzy " + winnerList;
            //else
            //    return winnerList;

        }
        public IEnumerable<string> GetPlayerHands() => players[0].GetCardNames();
        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " ma " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " kartę.\r\n";
                if (players[i].CardCount == 2 || players[i].CardCount == 3 || players[i].CardCount == 4)
                    description += " karty.\r\n";
                else
                    description += " kart.\r\n";
            }
            description += "Na kupce pozostało kart: " + stock.Count + Environment.NewLine;
            return description;

        }
    }
}
