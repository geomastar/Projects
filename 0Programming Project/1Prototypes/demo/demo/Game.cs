using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace demo
{
    class Game
    {
        private Map game_Map;
        private Tank[] game_CurrentTanksArray;
        private Projectile game_CurrentProjectile;

        public Game()
        {
            CompositionTarget.Rendering += UpdateEvent;
        }

        private void UpdateEvent(object Sender, EventArgs e)
        {
            
        }
    }
}
