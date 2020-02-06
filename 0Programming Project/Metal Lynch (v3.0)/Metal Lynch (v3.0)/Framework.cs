using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Metal_Lynch__v3._0_
{
    public class Framework
    {
        private Window framework_Window;
        private Canvas framework_Canvas;

        private Game framework_Game;
        private Menu framework_Menu;

        private List<MapData> framework_MapDataList;

        public struct MapData
        {
            public string mapName;
            public Point[] pointArray;

            public MapData(string name, Point[] points)
            {
                mapName = name;
                pointArray = points;
            }
        }

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

            framework_MapDataList = new List<MapData>();
            ReadMapDataFromFile();

            Random RNG = new Random();
            switch (RNG.Next(2))
            {
                case (0):
                    framework_Game = new Training(this, true, framework_MapDataList[RNG.Next(framework_MapDataList.Count)]);
                    break;
                case (1):
                    framework_Game = new _1v1(this, true, framework_MapDataList[RNG.Next(framework_MapDataList.Count)]);
                    break;
            }

            framework_Menu = new MainMenu(this);

            framework_Window.Content = framework_Canvas;
            //Adds the Canvas to the Window.
        }

        public void ChangeGameMode(GameModes gameMode, bool demoMode, MapData mapData)
        {
            framework_Canvas.Children.Remove(framework_Game.GetGame_Grid());
            framework_Game.DeactivateGame();

            switch (gameMode)
            {
                case GameModes.Training:
                    framework_Game = new Training(this, demoMode, mapData);
                    break;
                case GameModes._1v1:
                    framework_Game = new _1v1(this, demoMode, mapData);
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

        private void ReadMapDataFromFile()
        {
            string[] mapDataLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Resources\Maps.txt");

            string linePattern = @"^'\w*'{(\(\d+,\d+\))+}$";
            string namePattern = @"'\w*'";
            string coordinatePattern = @"\d+,\d+";

            foreach (string mapDataLine in mapDataLines)
            {
                if (Regex.IsMatch(mapDataLine, linePattern))
                {
                    string name = Regex.Match(mapDataLine, namePattern).Value.Substring(1, Regex.Match(mapDataLine, namePattern).Value.Length - 2);

                    MatchCollection coordinates = Regex.Matches(mapDataLine, coordinatePattern);

                    Point[] points = new Point[coordinates.Count];

                    int i = 0;
                    foreach (Match coordinate in coordinates)
                    {
                        string[] coordinateValues = coordinate.Value.Split(',');

                        points[i] = new Point(Convert.ToDouble(coordinateValues[0]), Convert.ToDouble(coordinateValues[1]));

                        i++;
                    }

                    framework_MapDataList.Add(new MapData(name, points));
                }
            }

            if (framework_MapDataList.Count == 0)
            {
                framework_MapDataList.Add(new MapData("Flat", new Point[] { new Point(0, 300), new Point(0, 300), new Point(1265, 300), new Point(1265, 300) }));
            }
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

        public List<MapData> GetFramework_MapDataList()
        {
            return framework_MapDataList;
            //Returns the mapDataList.
        }
    }
}
