using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noughts_and_Crosses
{
    public static class mechanics
    {
        public static Image getImage(bool currentPlayer)
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

        public static bool checkForWin(List<int> squaresList)
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (squaresList.Contains(i) && squaresList.Contains(i + 1) && squaresList.Contains(i + 2))
                {
                    return true;
                }
            }

            for (int i = 0; i <= 2; i++)
            {
                if (squaresList.Contains(i) && squaresList.Contains(i + 3) && squaresList.Contains(i + 6))
                {
                    return true;
                }
            }

            if (squaresList.Contains(0) && squaresList.Contains(4) && squaresList.Contains(8))
            {
                return true;
            }

            if (squaresList.Contains(2) && squaresList.Contains(4) && squaresList.Contains(6))
            {
                return true;
            }

            return false;
        }

        public static bool checkForTie(Button[] buttonList)
        {
            foreach (Button button in buttonList)
            {
                if (button.Enabled == true)
                {
                    return false;
                }                
            }

            return true;
        }

        public static void playTurn(Button currentButton, bool currentPlayer, List<int> squaresList, Button[] buttonList, string currentPlayerUserName)
        {
            currentButton.Image = mechanics.getImage(currentPlayer);

            if (mechanics.checkForWin(squaresList))
            {

                FinForm endDisplay = new FinForm(currentPlayerUserName);
                endDisplay.Show();
            }
            
            if (mechanics.checkForTie(buttonList))
            {
                FinForm endDisplay = new FinForm("Tie");
                endDisplay.Show();
            }
        }
    }
}
