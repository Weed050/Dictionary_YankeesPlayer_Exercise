namespace Dictionary_YankeesPlayer_Exercise
{
    public partial class Form1 : Form
    {
        Dictionary<int, JerseyNumber> retiredNumbers = new Dictionary<int, JerseyNumber>()
        {
            { 3, new JerseyNumber("Babe Ruth",1948) },
            { 4, new JerseyNumber("Lou Gehrig",1939) },
            { 5, new JerseyNumber("Joe DiMaggio",1952) },
            { 7, new JerseyNumber("Mickey Mantle",1969) },
            { 8, new JerseyNumber("Yogi Berra",1972) },
            { 10, new JerseyNumber("Phil Rizzuto",1985) },
            { 23, new JerseyNumber("Don Mattingly",1997) },
            { 42, new JerseyNumber("Jackie Robinson",1993) },
            { 44, new JerseyNumber("Reggie Jackson",1993) },
        };
        public Form1()
        {
            InitializeComponent();
            foreach (int i in retiredNumbers.Keys)
                comboBox1.Items.Add(i);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int number = comboBox1.SelectedIndex;
            JerseyNumber jerseyNumber = retiredNumbers[(int)comboBox1.SelectedItem];
            label1.Text = jerseyNumber.Player;
            label2.Text = jerseyNumber.YearRetired.ToString();
        }
    }
}