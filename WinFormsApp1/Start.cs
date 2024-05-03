namespace WinFormsApp1
{
    public partial class Start : Form
    {
        public static int characterCount { get; set; }
        public Start()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game Hangman = new();

            this.Hide();
            Hangman.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            characterCount = int.Parse(textBox1.Text);
        }
    }
}