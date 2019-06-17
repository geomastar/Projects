using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace demo
{
    class Game
    {
        private Window game_Window;
        private Canvas game_Canvas;
        private Map game_Map;
        private Tank game_Player;
        private Tank game_target;
        private Projectile game_CurrentProjectile;
        private Tank[] game_TankArray;

        private int gravity = 10;

        public Game(Window window, Canvas canvas)
        {            
            game_Window = window;
            game_Canvas = canvas;

            game_Map = new Map(2);
            game_Player = new Tank(100);
            game_target = new Tank(700);

            game_TankArray = new Tank[2] { game_Player, game_target };

            game_Map.AddToCanvas(game_Canvas);
            game_Player.AddToCanvas(game_Canvas);
            game_target.AddToCanvas(game_Canvas);

            CompositionTarget.Rendering += UpdateEvent;
            game_Window.KeyDown += KeyPressEvent;
        }

        private void UpdateEvent(object Sender, EventArgs e)
        {
            foreach (Tank tank in game_TankArray)
            {
                Point point1 = game_Player.GetTankPosition();

                IntersectionDetail innerTankMapIntersection = tank.GetTank_Path(false).Data.FillContainsWithDetail(game_Map.GetMap_Path().Data);
                IntersectionDetail outerTankMapIntersection = tank.GetTank_Path(true).Data.FillContainsWithDetail(game_Map.GetMap_Path().Data);

                if (outerTankMapIntersection == IntersectionDetail.Empty)
                {
                    tank.MoveTankDown();
                }

                if (innerTankMapIntersection == IntersectionDetail.Intersects)
                {
                    tank.MoveTankUp();
                }

                //game_Player.ChangeAngle(point1);
            }
        }

        private void KeyPressEvent(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {                
                case Key.A:                    
                    game_Player.MoveTankLeft();                    
                    break;
                case Key.D:
                    game_Player.MoveTankRight();
                    break;
            }
        }
    }
}
