using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Metal_Lynch__v2._0_
{
    public class Training : Game
    {
        private Tank training_Player1;
        private Tank training_Target;

        public Training(Framework framework, bool demoMode)
        {
            BaseConstructor(framework, demoMode);

            training_Player1 = new Tank(this, "Player1", 0, -1, 320, 100);
            training_Target = new Tank(this, "Target", 0, -1, 900, 100);

            game_TankArray = new Tank[2] { training_Player1, training_Target };

            game_CurrentPlayer = training_Player1;
            game_Winner = training_Player1;
            game_Stats.winner = training_Player1;

            CompositionTarget.Rendering += UpdateEvent;

            AddToCanvas();
            //Adds the Grid to the Canvas of the Framework.
        }

        private void UpdateEvent(object sender, EventArgs e)
        {
            if (game_NewTurn)
            {
                if (game_DemoMode) { GenerateRandomXLoc(); }
                game_NewTurn = false;
            }

            BaseUpdateEvent(new Tank[1] { training_Target });
        }

        protected override void EndGame()
        {
            CompositionTarget.Rendering -= UpdateEvent;
            game_FireButton.Toggle();
            game_Framework.ChangeMenu(Framework.Menus.ResultsMenu);
        }
    }
}
