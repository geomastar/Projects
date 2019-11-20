using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Metal_Lynch__v2._0_
{
    public abstract class Game
    {
        protected Framework game_Framework;

        protected Canvas game_MainCanvas;
        protected Canvas game_GUICanvas;

        protected Map game_Map;
        protected Projectile game_Projectile;
        protected Tank[] game_TankArray;

        protected MessageBox game_MessageBox;
        protected AimingIcon game_AimingIcon;
        protected FireButton game_FireButton;

        protected int game_Gravity;
        protected int game_Turn;

        public void AddToCanvas()
        {
            game_Framework.GetFramework_Canvas().Children.Add(game_MainCanvas);
            game_Framework.GetFramework_Canvas().Children.Add(game_MainCanvas);
            //Adds the two Canvas objects to the Canvas of the Framework.
        }

        protected void BaseConstructor(Framework framework)
        {
            game_Framework = framework;

            game_MainCanvas = new Canvas()
            {
                Height = 450,
                Width = 1280
            };

            game_GUICanvas = new Canvas()
            {
                Height = 240,
                Width = 1280
            };
        }

        public Canvas GetGame_MainCanvas()
        {
            return game_MainCanvas;
            //Returns the main Canvas.
        }

        public Canvas GetGame_GUICanvas()
        {
            return game_GUICanvas;
            //Returns the GUI Canvas.
        }
    }
}
