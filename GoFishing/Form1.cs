namespace GoFishing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private Game game;

        private void startGame_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textName.Text))
            {
                MessageBox.Show("Nie mo¿na wystartowaæ gry, potrzeba nazwy gracza.");
                return;
            }
            //game = new Game(Name = textName.Text, new List<string> { "Janek", "Bartek" }, textProgress);
            startGameBtn.Enabled = false;
            textName.Enabled = false;
            requestCardButton.Enabled = true;
            Update();
        }
        //private void UpdateGame()
        //{
        //    listHand.Items.Clear();
        //    foreach (string cardName in game.GetPlayerCardNames())
        //        listHand.Items.Add(cardName);
        //    textBooks.Text = game.DescribeBooks();
        //    textProgress.Text += game.DescribePlayerHands();
        //    textProgress.SelectionStart = textProgress.Text.Length;
        //    textProgress.ScrollToCaret();

        //}

        private void requestCardButton_Click(object sender, EventArgs e)
        {

            //    textProgress.Text = "";
            //    if (listHand.SelectedIndex < 0)
            //    {
            //        textProgress.Text = "Wybierz kartê";
            //        return;
            //    }
            //    if (game.PlayOneRound(listHand.SelectedIndex))
            //    {
            //        textProgress.Text += "Zwyciêzc¹ jest " + game.GetWinnerName();
            //        textBooks.Text = game.DescribeBooks();
            //        requestCardButton.Enabled = false;
            //    }
            //    else
            //        Update();

        }
    }
}