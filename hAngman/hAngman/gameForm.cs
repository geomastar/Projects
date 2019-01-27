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

        public gameForm(string theWord)
        {
            InitializeComponent();
            word = theWord;
        }

        private void gameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
