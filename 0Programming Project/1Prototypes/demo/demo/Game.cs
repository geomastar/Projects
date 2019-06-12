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

        private int gravity = 10;

        public Game(Window window, Canvas canvas)
        {            
            game_Window = window;
            game_Canvas = canvas;

            game_Map = new Map(2);
            game_Player = new Tank(100);

            game_Canvas.Children.Add(game_Map.GetMap_Path());
            game_Canvas.Children.Add(game_Player.GetTank_Path());

            CompositionTarget.Rendering += UpdateEvent;
            game_Window.KeyDown += KeyPressEvent;
        }

        private void UpdateEvent(object Sender, EventArgs e)
        {
            IntersectionDetail intersectionDetail_PlayerMap = game_Player.GetTank_Path().Data.FillContainsWithDetail(game_Map.GetMap_Path().Data);
            
            switch(intersectionDetail_PlayerMap)
            {
                case IntersectionDetail.Empty:
                    game_Player.MoveTankDown();
                    break;
                case IntersectionDetail.Intersects:
                    game_Player.MoveTankUp();
                    break;
            }            
        }

        private void KeyPressEvent(object sender, KeyEventArgs e)
        {
            switch(e.Key)
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
