using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment03
{
    public partial class Form1 : Form
    {
        int speed = 5;
        int score = 0;
        Random rand = new Random();
        bool gameOver = false; 

        public Form1()
        {
            Instructions instructionsForm = new Instructions();
            instructionsForm.Show();

            InitializeComponent();
          
            resetGame();

            gameTimer.Stop(); 

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instructions instructionsForm = new Instructions();
            instructionsForm.Show();
        }

        private void gameEngine(object sender, EventArgs e)
        {
            label1.Text = " Score: " + score;
            label2.Text = " Speed: " + speed;

            foreach (Control X in this.Controls)
            {
                if (X is PictureBox)
                {
                    X.Top -= speed;

                    if (X.Top + X.Height < 0)
                    {
                        X.Top = rand.Next(600, 800);
                        X.Left = rand.Next(5, 400); 
                    }

                    if (X.Tag.ToString() == "Balloon" && X.Top < -50)
                    {
                        gameTimer.Stop();
                        label1.Text += "Game Over! - Press Enter to Retry";
                        gameOver = true;
                    }
                }
            }
            /*
            if (score >= 10)
            {
                speed = 6;
            }

            if (score >= 20)
            {
                speed = 7;
            }

            if (score >= 35)
            {
                speed = 8;
            }
            */
            
        }

        int difficulty = 3; // 1 = slow, 2 = medium, 3 = fast

        private void popBalloon(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                var balloon = (PictureBox)sender;
                balloon.Top = rand.Next(600,800);
                balloon.Left = rand.Next(5, 400);
                score++;
            }

            if (difficulty == 1)
            {
                speed = 1;

                

                if (score >= 10)
                {
                    speed = 2;
                }

                if (score >= 20)
                {
                    speed = 3;
                }

                if (score >= 35)
                {
                    speed = 4;
                }

                label2.Text = " Speed: " + speed;
            }

            if (difficulty == 2)
            {
                speed = 3;



                if (score >= 10)
                {
                    speed = 4;
                }

                if (score >= 20)
                {
                    speed = 5;
                }

                if (score >= 35)
                {
                    speed = 6;
                }

                label2.Text = " Speed: " + speed;
            }

            if (difficulty == 3)
            {
                speed = 5;



                if (score >= 10)
                {
                    speed = 6;
                }

                if (score >= 20)
                {
                    speed = 7;
                }

                if (score >= 35)
                {
                    speed = 8;
                }

                label2.Text = " Speed: " + speed;
            } 
        }

        private void popBomb(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                Bomb.Image = Properties.Resources.boom;
                gameTimer.Stop();
                label1.Text += " Game Over! - Press Enter to retry ";
                gameOver = true; 
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                resetGame();

                
            }
            if (e.KeyCode == Keys.Enter)
            {


                gameTimer.Start();


            }
        }

        private void resetGame() 
        {
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox)
                {
                    X.Top = rand.Next(600, 800);
                    X.Left = rand.Next(5, 400);
                }
            }

            Bomb.Image = Properties.Resources.bomb;
            if (difficulty == 1)
            {
                speed = 1; 
            }

            if (difficulty == 2)
            {
                speed = 3;
            }

            if (difficulty == 3)
            {
                speed = 5;
            }
            score = 0;
            gameOver = false;
            label1.Text = "Score: " + score + " ";
            gameTimer.Start();
        }

        private void startgame(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = 1; 

            /*speed = 1;

            label2.Text = "Speed: " + speed;

            if (score >= 10)
            {
                speed = 2;
            }

            if (score >= 20)
            {
                speed = 3;
            }

            if (score >= 35)
            {
                speed = 4;
            } */
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = 2; 

            /*speed = 5;

            label2.Text = "Speed: " + speed;

            if (score >= 10)
            {
                speed = 6;
            }

            if (score >= 20)
            {
                speed = 7;
            }

            if (score >= 35)
            {
                speed = 8;
            } */
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = 3;
        }
    }
}
