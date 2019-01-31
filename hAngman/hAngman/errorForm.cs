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
    public partial class errorForm : Form
    {
        string errorText;

        public errorForm()
        {
            InitializeComponent();
            errorText = "ERROR:\n" +
                "-The word must be between 3 and 12 letters.\n" +
                "-It must only contain letters (no spaces, numbers or symbols).";
            errorLabel.Text = errorText;
        }

        private void errorForm_Load(object sender, EventArgs e)
        {

        }

        private void errorButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
