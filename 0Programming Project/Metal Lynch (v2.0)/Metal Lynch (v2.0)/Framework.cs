using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metal_Lynch__v2._0_
{
    public class Framework
    {
        private Window framework_Window;
        private Canvas framework_Canvas;

        private Game framework_Game;
        private Menu framework_Menu;

        public enum GameModes
        {
            Training,
            _1v1
        }
        public enum Menus
        {
            MainMenu,
            GameMenu,
            SettingsMenu
        }

        public Framework(Window window)
        {
            framework_Window = window;
            //Gives the Framework class access to the Window.

            framework_Canvas = new Canvas()
            {
                Height = window.Height,
                Width = window.Width
                //Creates the instance of Canvas where every graphical object
                //will be encapsulated. Gives it the same height and width as
                //the window.
            };

            framework_Game = new Training(this, true);

            framework_Menu = new MainMenu(this);

            framework_Window.Content = framework_Canvas;
            //Adds the Canvas to the Window.
        }

        public void ChangeGameMode(GameModes gameMode, bool demoMode)
        {
            framework_Canvas.Children.Remove(framework_Game.GetGame_Grid());

            switch (gameMode)
            {
                case GameModes.Training:
                    framework_Game = new Training(this, demoMode);
                    break;
                case GameModes._1v1:
                    framework_Game = new _1v1(this, demoMode);
                    break;
            }

            Panel.SetZIndex(framework_Game.GetGame_Grid(), 0);
            Panel.SetZIndex(framework_Menu.GetMenu_Canvas(), 1);
        }

        public void ChangeMenu(Menus menu)
        {
            framework_Canvas.Children.Remove(framework_Menu.GetMenu_Canvas());

            switch (menu)
            {
                case Menus.MainMenu:
                    framework_Menu = new MainMenu(this);
                    break;
                case Menus.GameMenu:
                    framework_Menu = new GameMenu(this);
                    break;
            }

            Panel.SetZIndex(framework_Game.GetGame_Grid(), 0);
            Panel.SetZIndex(framework_Menu.GetMenu_Canvas(), 1);
        }

        public Canvas GetFramework_Canvas()
        {
            return framework_Canvas;
            //Returns the Canvas.
        }
    }
}
