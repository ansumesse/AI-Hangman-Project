using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Win : Form
    {
        public Win()
        {
            InitializeComponent();
        }

        private void Win_Load(object sender, EventArgs e)
        {
            label1.Text = $"The AI did it! The correct word was";
            label2.Text = $" {Game.currentResult}";
            label3.Text = $" Can you beat the AI in the next round ? ";
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            // Center label1
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            // Center label2
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;

            // Center label3
            label3.Left = (this.ClientSize.Width - label3.Width) / 2;

            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game.currentResult = "";
            new Splash().Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
