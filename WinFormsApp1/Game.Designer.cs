namespace WinFormsApp1
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            listBox1 = new ListBox();
            Draw = new Button();
            panel1 = new Panel();
            label2 = new Label();
            AIGuess = new Button();
            Timer = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 403);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InfoText;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            listBox1.ForeColor = Color.Green;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(12, 72);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(388, 252);
            listBox1.TabIndex = 1;
            // 
            // Draw
            // 
            Draw.BackColor = Color.Firebrick;
            Draw.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Draw.ForeColor = SystemColors.ButtonHighlight;
            Draw.Location = new Point(531, 334);
            Draw.Name = "Draw";
            Draw.Size = new Size(117, 51);
            Draw.TabIndex = 2;
            Draw.Text = "Draw";
            Draw.UseVisualStyleBackColor = false;
            Draw.Click += Draw_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InfoText;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(390, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(398, 252);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 31);
            label2.TabIndex = 0;
            // 
            // AIGuess
            // 
            AIGuess.BackColor = Color.Green;
            AIGuess.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AIGuess.ForeColor = SystemColors.ControlLightLight;
            AIGuess.Location = new Point(148, 336);
            AIGuess.Name = "AIGuess";
            AIGuess.Size = new Size(117, 49);
            AIGuess.TabIndex = 4;
            AIGuess.Text = "AI Guess";
            AIGuess.UseVisualStyleBackColor = false;
            AIGuess.Click += AIGuess_Click;
            // 
            // Timer
            // 
            Timer.AutoSize = true;
            Timer.BackColor = Color.Transparent;
            Timer.Font = new Font("Stencil", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Timer.ForeColor = SystemColors.Window;
            Timer.Location = new Point(313, 9);
            Timer.Name = "Timer";
            Timer.Size = new Size(159, 40);
            Timer.TabIndex = 5;
            Timer.Text = "00:00:00";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new Size(800, 450);
            Controls.Add(Timer);
            Controls.Add(AIGuess);
            Controls.Add(Draw);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Game";
            Text = "Form2";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private Button Draw;
        private Panel panel1;
        private Button button2;
        private Button AIGuess;
        private Label label2;
        private Label Timer;
        private System.Windows.Forms.Timer timer1;
    }
}