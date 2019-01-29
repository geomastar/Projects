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
        Label[] letterLabels;
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
            game = new game(word);
        }

        private void gameForm_Load(object sender, EventArgs e)
        {

        }

        private void QButton_Click(object sender, EventArgs e)
        {
            QButton.Enabled = false;
            string correctGuesses = game.attempt('Q');
            for (int i = 0; i < correctGuesses.Length; i++)
            {
                letterLabels[Convert.ToInt16(correctGuesses.Substring(i, 1))].Text = "Q";
            }
        }
    }
}
