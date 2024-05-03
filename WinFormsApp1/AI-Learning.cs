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
    public partial class AI_Learning : Form
    {
        public AI_Learning()
        {
            InitializeComponent();
        }

        private void AI_Learning_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText("dictionary.txt", $"{textBox1.Text}\n");
            this.Hide();
            Game.currentResult = "";
            new Splash().Show();
        }
    }
}
