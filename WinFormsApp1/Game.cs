using HangmanSolver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WinFormsApp1
{
    public partial class Game : Form
    {
        int wordLen = Start.characterCount;
        int ticks = 0;
        bool timerStarted = false;
        public Game()
        {
            InitializeComponent();
        }
        Greedy_Algorithm search = new Greedy_Algorithm("dictionary.txt");
        public Button[] butArr = new Button[100];
        public static string currentResult { get; set; }
        char gussedChar = '_';
        int wrongGuesses = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            int buttonWidth = 40;
            int buttonSpacing = 10;
            int totalButtonsWidth = wordLen * buttonWidth + (wordLen - 1) * buttonSpacing;
            Point p = this.label1.Location;
            int y = p.Y;
            // Calculate the starting x-coordinate to center the buttons
            int startX = (this.ClientSize.Width - totalButtonsWidth) / 2;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Firebrick;

            for (int i = 0; i < wordLen; i++)
            {
                currentResult += "_";
                butArr[i] = new Button();
                butArr[i].Name = "button" + i.ToString();
                butArr[i].Width = buttonWidth;
                butArr[i].Height = 40;
                butArr[i].Location = new Point(startX + i * (buttonWidth + buttonSpacing), y);
                butArr[i].TextAlign = ContentAlignment.MiddleCenter;
                butArr[i].Text = "_";
                butArr[i].BackColor = Color.Black;
                butArr[i].ForeColor = Color.White;
                butArr[i].Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                butArr[i].Click += new EventHandler(Letters_Click);
                Controls.Add(butArr[i]);
            }
            Timer.Left = (this.ClientSize.Width - Timer.Width) / 2;
        }
        private static Random r = new Random();
        private static string StringifyGuesses(IEnumerable<string> searchPossibleSolutions)
        {
            var somePossibilities = searchPossibleSolutions.OrderBy(obj => r.Next()).Take(4); //4 possible random solutions
            StringBuilder builder = new StringBuilder();
            foreach (var possibility in somePossibilities)
            {
                builder.Append(possibility);
                builder.Append(", ");
            }
            builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
        }
        private void Letters_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {

                clickedButton.Text = gussedChar.ToString();


                // Find the index of the clicked button in the array
                int index = Array.IndexOf(butArr, clickedButton);

                // Update the currentResult string
                if (index != -1 && index < currentResult.Length)
                {
                    char[] resultArray = currentResult.ToCharArray();
                    resultArray[index] = gussedChar;
                    currentResult = new string(resultArray);
                }
                search.GuessedCharFilter(gussedChar, currentResult);
                if (search._PossibleWords.Count() > 0)
                {
                    if (search.HasSolution())
                    {
                        currentResult = search.Solution();
                        for (int i = 0; i < currentResult.Length; i++)
                        {
                            butArr[i].Text = currentResult[i].ToString();
                        }
                        this.Hide();
                        Win win = new();
                        win.Show();
                        timer1.Stop();
                    }
                    listBox1.Items.Add($"There are {search._PossibleWords.Count()} choices");
                    listBox1.Items.Add($"The word could be: {StringifyGuesses(search._PossibleWords)}");
                }
                else
                {
                    this.Hide();
                    new AI_Learning().Show();
                    timer1.Stop();
                }
               
            }
        }
        private void Draw_Click(object sender, EventArgs e)
        {
            wrongGuesses++;

            label2.Text = $"Lives Lift: {7 - wrongGuesses}";
            panel1.Invalidate();
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                //search.WordSizeFilter(wordLen);
                char oldGuess = gussedChar;
                search.GuessedCharFilter(oldGuess, currentResult);
                gussedChar = search.GuessBestCharacter(currentResult);
                listBox1.Items.Add($"AI Best Guess: {gussedChar}");
                if (search.HasSolution())
                {
                    currentResult = search.Solution();
                    for (int i = 0; i < currentResult.Length; i++)
                    {
                        butArr[i].Text = currentResult[i].ToString();
                    }
                    this.Hide();
                    Win win = new();
                    win.Show();
                }
                if (wrongGuesses == 7)
                {
                    Lose lose = new();
                    this.Hide();
                    lose.Show();
                    timer1.Stop();
                }
            }
        }
        private void AIGuess_Click(object sender, EventArgs e)
        {
            //timer1.Stop();
            //ticks = 0;
            timer1.Start();
            timerStarted = true;
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                search.WordSizeFilter(wordLen);
                char oldGuess = gussedChar;

                gussedChar = '_';
                char[] resultArray = currentResult.ToCharArray();
                for (int i = 0; i < resultArray.Length; i++)
                {
                    if (resultArray[i] == '_')
                    {
                        resultArray[i] = gussedChar;
                        break;
                    }
                }
                currentResult = new string(resultArray);
                gussedChar = search.GuessBestCharacter(currentResult);
                //if (Flag)
                {
                    search.GuessedCharFilter(oldGuess, currentResult);
                }
                listBox1.Items.Add($"AI Best Guess: {gussedChar}");

                if (search.HasSolution())
                {
                    currentResult = search.Solution();
                    for (int i = 0; i < currentResult.Length; i++)
                    {
                        butArr[i].Text = currentResult[i].ToString();
                    }
                    this.Hide();
                    Win win = new();
                    win.Show();
                    timer1.Stop();
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White, 2);

            // Draw the gallows
            g.DrawLine(pen, new Point(50, 280), new Point(50, 100));
            g.DrawLine(pen, new Point(50, 100), new Point(150, 100));
            g.DrawLine(pen, new Point(150, 100), new Point(150, 130));

            // Draw the hangman based on the number of wrong guesses
            switch (wrongGuesses)
            {
                case 1:
                    // Draw head
                    g.DrawEllipse(pen, 130, 130, 40, 40);
                    g.FillEllipse(Brushes.White, 140, 140, 6, 6);
                    g.FillEllipse(Brushes.White, 160, 140, 6, 6);
                    break;
                case 2:
                    // Draw body
                    g.DrawLine(pen, new Point(150, 170), new Point(150, 220));
                    goto case 1;
                case 3:
                    // Draw left arm
                    g.DrawLine(pen, new Point(150, 180), new Point(120, 200));
                    goto case 2;
                case 4:
                    // Draw right arm
                    g.DrawLine(pen, new Point(150, 180), new Point(180, 200));
                    goto case 3;
                case 5:
                    // Draw left leg
                    g.DrawLine(pen, new Point(150, 220), new Point(120, 260));
                    goto case 4;
                case 6:
                    // Draw right leg
                    g.DrawLine(pen, new Point(150, 220), new Point(180, 260));
                    goto case 5;
                case 7:
                    // Draw smile
                    g.DrawArc(pen, 140, 150, 20, 20, 0, -180);
                    goto case 6;
                    // Add more cases for additional body parts if desired
            }

            pen.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks = timerStarted ? ticks + 1 : 0;
            Timer.Text = TimeSpan.FromSeconds(ticks).ToString(@"hh\:mm\:ss");
        }
    }
}
