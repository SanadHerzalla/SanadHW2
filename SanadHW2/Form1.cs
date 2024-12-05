using System;

namespace SanadHW2
{
    public partial class Form1 : Form
    {
        private int num;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            num = random.Next(1, 1001);
            this.BackColor = SystemColors.Control;
            lblMessage.Text = "Guess result will appear here";
            txtGuess.Text = string.Empty;
            txtGuess.Enabled = true;
            txtGuess.Focus();
        }
        
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void txtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (int.TryParse(txtGuess.Text, out int guess))
                {
                 
                    if (guess == num)
                    {
                        MessageBox.Show("Correct!", "Congratulations");
                        this.BackColor = Color.Green; 
                        txtGuess.Enabled = false; 
                    }
                    else
                    {
                        if(guess < num)
                        {
                            lblMessage.Text = "Too Low! Try again";
                        }
                        else
                        {
                            lblMessage.Text = "Too High! Try again";
                        }

                        if(guess < num)
                        {
                            this.BackColor = Color.Blue;
                        }
                        else
                        {
                            this.BackColor= Color.Red;
                        }


                    }

                    txtGuess.Clear();
                    txtGuess.Focus(); 
                }
                else
                {
                    lblMessage.Text = "Please enter a valid number.";
                    txtGuess.Clear();
                    txtGuess.Focus();
                }
            }
        }
    }
}

