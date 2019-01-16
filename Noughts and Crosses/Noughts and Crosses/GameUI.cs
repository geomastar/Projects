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
        List<int> noughtSquares;
        List<int> crossSquares;
        int turn;
        List<int> currentList;

        public GameUI(string player1, string player2)
        {
            InitializeComponent();
            noughtsUserName = player1;
            crossesUserName = player2;
            noughtSquares = new List<int>();
            crossSquares = new List<int>();
        }

        private void GameUI_Load(object sender, EventArgs e)
        {
            currentPlayer = false;
        }

        private void square1Button_Click(object sender, EventArgs e)
        {
            if (currentPlayer)
            {
                currentList = crossSquares;
            }
            else
            {
                currentList = noughtSquares;
            }
            currentList.Add(1);
            mechanics.playTurn(square1Button, currentPlayer;
            currentPlayer = !currentPlayer;
        }

        private void square2Button_Click(object sender, EventArgs e)
        {

        }

        private void square3Button_Click(object sender, EventArgs e)
        {

        }


        private void square4Button_Click(object sender, EventArgs e)
        {

        }

        private void square5Button_Click(object sender, EventArgs e)
        {

        }

        private void square6Button_Click(object sender, EventArgs e)
        {

        }

        private void square7Button_Click(object sender, EventArgs e)
        {

        }

        private void square8Button_Click(object sender, EventArgs e)
        {

        }

        private void square9Button_Click(object sender, EventArgs e)
        {
          
        }
    }
}
