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

        public Training(Framework framework)
        {
            BaseConstructor(framework);

            training_Player1 = new Tank(this, 0, -1, 320, 100);
            training_Target = new Tank(this, 0, -1, 900, 100);

            game_TankArray = new Tank[2] { training_Player1, training_Target };

            game_CurrentPlayer = game_TankArray[0];

            CompositionTarget.Rendering += UpdateEvent;

            AddToCanvas();
            //Adds the Grid to the Canvas of the Framework.
        }

        private void UpdateEvent(object sender, EventArgs e)
        {
            BaseUpdateEvent(new Tank[1] { training_Target });
        }
    }
}
