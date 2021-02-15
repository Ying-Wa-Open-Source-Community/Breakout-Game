using System;
using System.Windows.Forms;
namespace Bulls_and_Cows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
        }
        public int finishornot = 0;
        public int n1 = 0;
        public int n2 = 0;
        public int n3 = 0;
        public int n4 = 0;
        public int T = 0;
        public int input = 0;
        public int ans = 0;
        public int time_s = 0;
        public int time_m = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                input = Convert.ToInt32(textBox1.Text);
                double in1 = Math.Truncate((double)input / 1000);
                double in2 = Math.Truncate((input - 1000 * in1) / 100);
                double in3 = Math.Truncate((input - 1000 * in1 - 100 * in2) / 10);
                double in4 = Math.Truncate(input - 1000 * in1 - 100 * in2 - 10 * in3);
                if (in1 == in2 || in1 == in3 || in1 == in4 || in2 == in3 || in2 == in4 || in3 == in4)
                {
                    MessageBox.Show("No repeat number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto the_end;
                }
                if (input < 0)
                {
                    MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto the_end;
                }
                int RP = 0, P_WP = 0;
                if (n1 == in1)
                {
                    RP++;
                }
                if (n2 == in2)
                {
                    RP++;
                }
                if (n3 == in3)
                {
                    RP++;
                }
                if (n4 == in4)
                {
                    RP++;
                }
                if (n1 == in2)
                {
                    P_WP++;
                }
                if (n1 == in3)
                {
                    P_WP++;
                }
                if (n1 == in4)
                {
                    P_WP++;
                }
                if (n2 == in1)
                {
                    P_WP++;
                }
                if (n2 == in3)
                {
                    P_WP++;
                }
                if (n2 == in4)
                {
                    P_WP++;
                }
                if (n3 == in1)
                {
                    P_WP++;
                }
                if (n3 == in2)
                {
                    P_WP++;
                }
                if (n3 == in4)
                {
                    P_WP++;
                }
                if (n4 == in1)
                {
                    P_WP++;
                }
                if (n4 == in2)
                {
                    P_WP++;
                }
                if (n4 == in3)
                {
                    P_WP++;
                }
                T++;
                string result = RP + "A" + P_WP + "B";
                if (ans == input)
                {
                    finishornot++;
                    timer1.Stop();
                    textBox5.Text = (input < 1000 ? "0" : "") + Convert.ToString(input) + "(" + result + ")";
                    textBox2.AppendText(T + "\r\n");
                    textBox3.AppendText(input + "\r\n");
                    textBox4.AppendText(result + "\r\n");
                    textBox1.Text = "";
                    MessageBox.Show("You got the answer: " + (ans < 999 ? "0" : "") + ans + "!\n" + "You use " + T + " time" + (T == 1 ? " only!" : "s!") + "\nYou use " + time_s + "!");
                    DialogResult r = MessageBox.Show("Do you want to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Result:\n" + result);
                    textBox5.Text = (input < 1000 ? "0" : "") + Convert.ToString(input) + "(" + result + ")";
                    textBox2.AppendText(T + "\r\n");
                    textBox3.AppendText((input < 1000 ? "0" : "") + input + "\r\n");
                    textBox4.AppendText(result + "\r\n");
                    textBox1.Text = "";
                }
            the_end:;
            }
            catch
            {
                MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;

        rr:;
            Random ran = new Random();
            n1 = ran.Next(0, 9);
            n2 = ran.Next(0, 9);
            n3 = ran.Next(0, 9);
            n4 = ran.Next(0, 9);
            ans = n1 * 1000 + n2 * 100 + n3 * 10 + n4;
            if (n1 == n2 || n1 == n3 || n1 == n4 || n2 == n3 || n2 == n4 || n3 == n4)
            {
                goto rr;
            }
            timer1.Start();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to restart the game?", "restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes && finishornot == 0)
            {
                MessageBox.Show("By the way, the answer of this game is " + (ans < 1000 ? "0" : "") + ans);
                Application.Restart();
            }
            else if (r == DialogResult.Yes && finishornot != 0)
            {
                Application.Restart();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to exit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                MessageBox.Show("By the way, the answer of this game is " + (ans < 999 ? "0" : "") + ans);
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Henry (v1.1)\nCompleted on 11/8/2020", "About");
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bulls and Cows is a digital - cracking game.The game rules were followed:\nAt first, the system will randomly pick a 4-digits number(but the 4 numbers are not repeated), you need to discover them to win!\nEnter a 4-digits number.\nThe system will give you back a tip, which looks like this:\n(number x)A(number y)B\n\"number x\" means how many number(s) you have got in the Right Position. For example, if the answer was '1234', and if you guess: 1324, then the number x will be 2 because only 2 numbers (1 and 4) was in the right position.\n\"number y\" means how many number(s)  you have got in the Wrong Position, but it's in the whole number. Using the last example,  if the answer was '1234', and if you guess: 1324, then the number x will be 2 because it has only 2 numbers (1 and 4) was in the right position; and the number y will be 2 because only 2 number (2 and 3) is in the wrong position.\nGoto \"https://en.wikipedia.org/wiki/Bulls_and_Cows\" to find more help", "How to play?");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_s++;
            if (time_s == 60)
            {
                time_s = 0;
                time_m++;
            }
            textBox6.Text = (time_m < 10 ? "0" : "") + time_m.ToString() + ":" + (time_s < 10 ? "0" : "") + time_s.ToString();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && finishornot == 0)
            {
                try
                {
                    input = Convert.ToInt32(textBox1.Text);
                    double in1 = Math.Truncate((double)input / 1000);
                    double in2 = Math.Truncate((input - 1000 * in1) / 100);
                    double in3 = Math.Truncate((input - 1000 * in1 - 100 * in2) / 10);
                    double in4 = Math.Truncate(input - 1000 * in1 - 100 * in2 - 10 * in3);
                    if (in1 == in2 || in1 == in3 || in1 == in4 || in2 == in3 || in2 == in4 || in3 == in4)
                    {
                        MessageBox.Show("No repeat number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto the_end;
                    }
                    if (input < 0)
                    {
                        MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto the_end;
                    }
                    int RP = 0, P_WP = 0;
                    if (n1 == in1)
                    {
                        RP++;
                    }
                    if (n2 == in2)
                    {
                        RP++;
                    }
                    if (n3 == in3)
                    {
                        RP++;
                    }
                    if (n4 == in4)
                    {
                        RP++;
                    }
                    if (n1 == in2)
                    {
                        P_WP++;
                    }
                    if (n1 == in3)
                    {
                        P_WP++;
                    }
                    if (n1 == in4)
                    {
                        P_WP++;
                    }
                    if (n2 == in1)
                    {
                        P_WP++;
                    }
                    if (n2 == in3)
                    {
                        P_WP++;
                    }
                    if (n2 == in4)
                    {
                        P_WP++;
                    }
                    if (n3 == in1)
                    {
                        P_WP++;
                    }
                    if (n3 == in2)
                    {
                        P_WP++;
                    }
                    if (n3 == in4)
                    {
                        P_WP++;
                    }
                    if (n4 == in1)
                    {
                        P_WP++;
                    }
                    if (n4 == in2)
                    {
                        P_WP++;
                    }
                    if (n4 == in3)
                    {
                        P_WP++;
                    }
                    T++;
                    if (ans == input)
                    {
                        finishornot++;
                        string result = RP + "A" + P_WP + "B";
                        textBox5.Text = Convert.ToString(input) + "(" + result + ")";
                        textBox2.AppendText(T + "\r\n");
                        textBox3.AppendText(input + "\r\n");
                        textBox4.AppendText(result + "\r\n");
                        textBox1.Text = "";
                        timer1.Stop();
                        MessageBox.Show("You got the answer: " + (ans < 1000 ? "0" : "") + ans + "!\n" + "You use " + T + " time" + (T == 1 ? " only!" : "s!") + "\nYou use " + textBox6.Text + "!");
                        DialogResult r = MessageBox.Show("Do you want to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        button1.Enabled = false;
                        textBox1.Enabled = false;
                    }
                    else
                    {
                        string result = RP + "A" + P_WP + "B";
                        MessageBox.Show("Result:\n" + result);
                        textBox5.Text = Convert.ToString(input) + "(" + result + ")";
                        textBox2.AppendText(T + "\r\n");
                        textBox3.AppendText((input < 999 ? "0" : "") + input + "\r\n");
                        textBox4.AppendText(result + "\r\n");
                        textBox1.Text = "";
                    }
                the_end:;
                }
                catch
                {
                    MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}