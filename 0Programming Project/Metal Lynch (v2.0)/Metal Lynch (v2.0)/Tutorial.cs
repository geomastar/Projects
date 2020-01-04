using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metal_Lynch__v2._0_
{
    public class Tutorial : Game
    {
        private Tank tutorial_Player1;
        private Tank tutorial_Target;

        private ProgressBar tutorial_Player1HealthBar;
        private ProgressBar tutorial_TargetHealthBar;

        private ProgressBar tutorial_FuelBar;

        protected int tutorial_CentreBoundary;

        public Tutorial(Framework framework, bool demoMode)
        {
            game_Framework = framework;

            BaseConstructor(game_Framework, demoMode);
        }

        protected override void UpdateEvent(object sender, EventArgs e)
        {

        }

        public override void EndGame()
        {

        }
    }
}
