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

        public Canvas Getgame_MainCanvas()
        {
            return game_MainCanvas;
        }

        public Canvas Getgame_GUICanvas()
        {
            return game_GUICanvas;
        }
    }
}
