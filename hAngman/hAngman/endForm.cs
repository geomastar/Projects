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
    public partial class endForm : Form
    {
        bool result;
        string word;

        public endForm(bool theResult, string theWord)
        {
            InitializeComponent();
            result = theResult;
            word = theWord;
            if (result) { endLabel.Text += "You Win!    The word was " + word; hangmanPictureBox.Image = Resources._13; }
            else { endLabel.Text += "You Lose!    The word was " + word; hangmanPictureBox.Image = Resources._12; }
        }

        private void endForm_Load(object sender, EventArgs e)
        {

        }

        private void endButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
