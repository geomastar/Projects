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
            if (squaresList.Contains(1) && )
        }

        public static void playTurn(Button currentButton, bool currentPlayer, List<int> squaresList)
        {
            currentButton.Image = mechanics.getImage(currentPlayer);

            if (mechanics.checkForWin(squaresList))
            {

            }
        }
    }
}
