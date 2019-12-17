using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Metal_Lynch__v2._0_
{
    public class _1v1 : Game
    {        
        private Tank _1v1_Player1;
        private Tank _1v1_Player2;

        protected int game_CentreBoundary;

        public _1v1(Framework framework)
        {
            game_Framework = framework;

            BaseConstructor(game_Framework);

            _1v1_Player1 = new Tank(this, 0, 320, 100);
            _1v1_Player2 = new Tank(this, 0, 900, 100);

            game_TankArray = new Tank[2] { _1v1_Player1, _1v1_Player2 };

            game_CentreBoundary = 640;

            CompositionTarget.Rendering += UpdateEvent;

            AddToCanvas();
            //Adds the Grid to the Canvas of the Framework.
        }

        private void UpdateEvent(object sender, EventArgs e)
        {
            game_CurrentPlayer = game_TankArray[(game_Turn-1) % 2];

            foreach (Tank tank in game_TankArray)
            {
                if (tank == game_TankArray[0])
                {
                    if (tank.GetTank_TranslateTransform().X + 76 > game_CentreBoundary) { tank.MoveLeft(); }
                }
                else
                {
                    if (tank.GetTank_TranslateTransform().X < game_CentreBoundary) { tank.MoveRight(); }
                }
            }

            BaseUpdateEvent(new Tank[1] { game_TankArray[game_Turn % 2] });
        }
    }
}
