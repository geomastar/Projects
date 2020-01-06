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
            SettingsMenu,
            PauseMenu,
            ResultsMenu
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

            Random RNG = new Random();
            switch (RNG.Next(2))
            {
                case (0):
                    framework_Game = new Training(this, true);
                    break;
                case (1):
                    framework_Game = new _1v1(this, true);
                    break;
            }

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

                case Menus.PauseMenu:
                    framework_Menu = new PauseMenu(this);
                    break;
                case Menus.ResultsMenu:
                    framework_Menu = new ResultsMenu(this);
                    break;
            }

            Panel.SetZIndex(framework_Game.GetGame_Grid(), 0);
            Panel.SetZIndex(framework_Menu.GetMenu_Canvas(), 1);
        }

        public Window GetFramework_Window()
        {
            return framework_Window;
            //Returns the Window.
        }

        public Canvas GetFramework_Canvas()
        {
            return framework_Canvas;
            //Returns the Canvas.
        }

        public Game GetFramework_Game()
        {
            return framework_Game;
            //Returns the Game.
        }

        public Menu GetFramework_Menu()
        {
            return framework_Menu;
            //Returns the Menu.
        }
    }
}
