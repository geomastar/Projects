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
    public partial class GameUI : Form
    {
        string noughtsUserName;
        string crossesUserName;
        bool currentPlayer;
        int[] coords;
        Model game = new Model();

        public GameUI(string player1, string player2)
        {
            InitializeComponent();
            noughtsUserName = player1;
            crossesUserName = player2;
        }

        private void GameUI_Load(object sender, EventArgs e)
        {
            coords = new int[2];
            currentPlayer = false;
        }

        private void square1Button_Click(object sender, EventArgs e)
        {
            coords[0] = 0;
            coords[1] = 2;
             
        }

        private void square2Button_Click(object sender, EventArgs e)
        {
            coords[0] = 1;
            coords[1] = 2;
        }

        private void square3Button_Click(object sender, EventArgs e)
        {
            coords[0] = 2;
            coords[1] = 2;
        }

        private void square4Button_Click(object sender, EventArgs e)
        {
            coords[0] = 0;
            coords[1] = 1;
        }

        private void square5Button_Click(object sender, EventArgs e)
        {
            coords[0] = 1;
            coords[1] = 1;
        }

        private void square6Button_Click(object sender, EventArgs e)
        {
            coords[0] = 2;
            coords[1] = 1;
        }

        private void square7Button_Click(object sender, EventArgs e)
        {
            coords[0] = 0;
            coords[1] = 0;
        }

        private void square8Button_Click(object sender, EventArgs e)
        {
            coords[0] = 1;
            coords[1] = 0;
        }

        private void square9Button_Click(object sender, EventArgs e)
        {
            coords[0] = 2;
            coords[1] = 0;
        }

        private Image newImage()
        {
            if (currentPlayer)
            {
                return Properties.Resources.cross;
            }
            else
            {
                return Properties.Resources.nought;
            }
        }
    }
}
