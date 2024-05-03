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

namespace WinFormsApp1
{
    public partial class Lose : Form
    {
        public Lose()
        {
            InitializeComponent();
        }

        private void Lose_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Splash().Show();
        }
    }
}
