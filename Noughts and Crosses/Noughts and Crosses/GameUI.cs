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
        string currentPlayerUserName;
        bool currentPlayer;
        List<int> noughtSquares;
        List<int> crossSquares;
        List<int> currentList;
        Button[] buttonList;

        public GameUI(string player1, string player2)
        {
            InitializeComponent();

            noughtsUserName = player1;
            crossesUserName = player2;
            currentPlayerLabel.Text = noughtsUserName;
            noughtSquares = new List<int>();
            crossSquares = new List<int>();
            buttonList = new Button[9] 
            {
                square1Button,
                square2Button,
                square3Button,
                square4Button,
                square5Button,
                square6Button,
                square7Button,
                square8Button,
                square9Button
            };
        }

        private void GameUI_Load(object sender, EventArgs e)
        {
            currentPlayer = false;
        }

        private void square1Button_Click(object sender, EventArgs e)
        {
            nextTurn(0);
        }

        private void square2Button_Click(object sender, EventArgs e)
        {
            nextTurn(1);
        }

        private void square3Button_Click(object sender, EventArgs e)
        {
            nextTurn(2);
        }

        private void square4Button_Click(object sender, EventArgs e)
        {
            nextTurn(3);
        }

        private void square5Button_Click(object sender, EventArgs e)
        {
            nextTurn(4);
        }

        private void square6Button_Click(object sender, EventArgs e)
        {
            nextTurn(5);
        }

        private void square7Button_Click(object sender, EventArgs e)
        {
            nextTurn(6);
        }

        private void square8Button_Click(object sender, EventArgs e)
        {
            nextTurn(7);
        }

        private void square9Button_Click(object sender, EventArgs e)
        {
            nextTurn(8);
        }

        private void nextTurn(int currentButton)
        {
            if (currentPlayer)
            {
                currentList = crossSquares;
                currentPlayerLabel.Text = noughtsUserName;
                currentPlayerUserName = noughtsUserName;
            }
            else
            {
                currentList = noughtSquares;
                currentPlayerLabel.Text = crossesUserName;
                currentPlayerUserName = crossesUserName;
            }
            currentList.Add(currentButton);
            buttonList[currentButton].Enabled = false;
            mechanics.playTurn(buttonList[currentButton], currentPlayer, currentList, buttonList, currentPlayerUserName);
            currentPlayer = !currentPlayer;            
        }
    }
}
