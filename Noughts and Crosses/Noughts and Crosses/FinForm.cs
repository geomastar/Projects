using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noughts_and_Crosses
{
    public partial class FinForm : Form
    {
        public FinForm(string winner)
        {
            InitializeComponent();
            winnerLabel.Text = winner;
        }

        private void FinForm_Load(object sender, EventArgs e)
        {

        }
    }
}
