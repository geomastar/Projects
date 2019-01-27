using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hAngman
{
    public partial class wordSelectForm : Form
    {
        string word;

        public wordSelectForm()
        {
            InitializeComponent();
        }

        private void wordSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            word = wordSelectTextBox.Text;

            if (word.All(Char.IsLetter) && word.Length >= 9)
            {
                gameForm newGameForm = new gameForm(word);
                newGameForm.Show();
                Close();
            }
            else
            {
                errorForm newErrorForm = new errorForm();
                newErrorForm.Show();
            }
        }
    }
}
