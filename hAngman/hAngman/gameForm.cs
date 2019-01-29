using hAngman.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hAngman
{
    public partial class gameForm : Form
    {
        string word;
        int manHang;
        Label[] letterLabels;
        Image[] steps;
        game game;

        public gameForm(string theWord)
        {
            InitializeComponent();
            word = theWord;
            letterLabels = new Label[9] 
            {
                Letter0Label,
                Letter1Label,
                Letter2Label,
                Letter3Label,
                Letter4Label,
                Letter5Label,
                Letter6Label,
                Letter7Label,
                Letter8Label
            };
            steps = new Image[12]
            {
                Resources._1,
                Resources._2,
                Resources._3,
                Resources._4,
                Resources._5,
                Resources._6,
                Resources._7,
                Resources._8,
                Resources._9,
                Resources._10,
                Resources._11,
                Resources._12,
            };
            game = new game(word);
            manHang = 0;
        }

        private void gameForm_Load(object sender, EventArgs e)
        {

        }

        private void QButton_Click(object sender, EventArgs e)
        {
            QButton.Enabled = false;
            string correctGuesses = game.attempt('Q');
            if (correctGuesses.Length > 0)
            {
                for (int i = 0; i < correctGuesses.Length; i++)
                {
                    letterLabels[Convert.ToInt16(correctGuesses.Substring(i, 1))].Text = "Q";
                }
            }
            else
            {
                manHang++;
                hangmanPictureBox.Image = steps[manHang - 1];
            }
            switch(game.gameEndCheck(manHang))
            {
                case (-1):
                    //lose
                    break;
                case (1):
                    //win
                    break;
            }
        }
    }
}
