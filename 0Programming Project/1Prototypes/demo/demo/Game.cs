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
        private Canvas game_Canvas;
        private Map game_Map;
        private Tank game_Player;
        private Tank game_target;
        private Projectile game_CurrentProjectile;

        public Game(Canvas canvas)
        {
            CompositionTarget.Rendering += UpdateEvent;

            game_Canvas = canvas;

            game_Map = new Map(1);

            game_Player = new Tank();

            game_Canvas.Children.Add(game_Map.GetMap_Path());
        }

        private void UpdateEvent(object Sender, EventArgs e)
        {
            
        }
    }
}
