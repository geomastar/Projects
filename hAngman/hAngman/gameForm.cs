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
        Label[] letterLabels;
        Image[] images;
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
            images = new Image[12]
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
        }

        private void gameForm_Load(object sender, EventArgs e)
        {

        }

        private void newAttempt(char currentLetter, Button currentButton)
        {
            currentButton.Enabled = false;
            string correctGuesses = game.attempt(currentLetter);
            if (correctGuesses.Length > 0)
            {
                for (int i = 0; i < correctGuesses.Length; i++)
                {
                    letterLabels[Convert.ToInt16(correctGuesses.Substring(i, 1))].Text = Convert.ToString(currentLetter);
                }
            }
            else
            {
                hangmanPictureBox.Image = images[game.GetWrongGuesses() - 1];
            }
            switch (game.gameEndCheck())
            {
                case (-1):
                    //lose
                    endForm loseForm = new endForm(false, word);
                    loseForm.Show();
                    Close();
                    break;
                case (1):
                    //win
                    endForm winForm = new endForm(true, word);
                    winForm.Show();
                    Close();
                    break;
            }
        }

        private void QButton_Click(object sender, EventArgs e)
        {
            newAttempt('Q', QButton);
        }
        private void WButton_Click(object sender, EventArgs e)
        {
            newAttempt('W', WButton);
        }
        private void EButton_Click(object sender, EventArgs e)
        {
            newAttempt('E', EButton);
        }
        private void RButton_Click(object sender, EventArgs e)
        {
            newAttempt('R', RButton);
        }
        private void TButton_Click(object sender, EventArgs e)
        {
            newAttempt('T', TButton);
        }
        private void YButton_Click(object sender, EventArgs e)
        {
            newAttempt('Y', YButton);
        }
        private void UButton_Click(object sender, EventArgs e)
        {
            newAttempt('U', UButton);
        }
        private void IButton_Click(object sender, EventArgs e)
        {
            newAttempt('I', IButton);
        }
        private void OButton_Click(object sender, EventArgs e)
        {
            newAttempt('O', OButton);
        }
        private void PButton_Click(object sender, EventArgs e)
        {
            newAttempt('P', PButton);
        }
        private void AButton_Click(object sender, EventArgs e)
        {
            newAttempt('A', AButton);
        }
        private void SButton_Click(object sender, EventArgs e)
        {
            newAttempt('S', SButton);
        }   
        private void DButton_Click(object sender, EventArgs e)
        {
            newAttempt('D', DButton);
        }
        private void FButton_Click(object sender, EventArgs e)
        {
            newAttempt('F', FButton);
        }
        private void GButton_Click(object sender, EventArgs e)
        {
            newAttempt('G', GButton);
        }
        private void HButton_Click(object sender, EventArgs e)
        {
            newAttempt('H', HButton);
        }
        private void JButton_Click(object sender, EventArgs e)
        {
            newAttempt('J', JButton);
        }
        private void KButton_Click(object sender, EventArgs e)
        {
            newAttempt('K', KButton);
        }
        private void LButton_Click(object sender, EventArgs e)
        {
            newAttempt('L', LButton);
        }
        private void ZButton_Click(object sender, EventArgs e)
        {
            newAttempt('Z', ZButton);
        }
        private void XButton_Click(object sender, EventArgs e)
        {
            newAttempt('X', XButton);
        }
        private void CButton_Click(object sender, EventArgs e)
        {
            newAttempt('C', CButton);
        }
        private void VButton_Click(object sender, EventArgs e)
        {
            newAttempt('V', VButton);
        }
        private void BButton_Click(object sender, EventArgs e)
        {
            newAttempt('B', BButton);
        }
        private void NButton_Click(object sender, EventArgs e)
        {
            newAttempt('N', NButton);
        }
        private void MButton_Click(object sender, EventArgs e)
        {
            newAttempt('M', MButton);
        }
    }
}
