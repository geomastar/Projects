﻿using System;
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
            public int angleStep;
            public double[] angleArray;

            public MapData(string name, Point[] points, int step)
            {
                mapName = name;
                pointArray = points;
                angleStep = step;
                angleArray = new double[1280 / angleStep];
            }
        }

        public enum GameModes
        {
            Training,
            _1v1,
            _4PlayerFFA
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

            framework_Game = new MapLoader(this);

            framework_Game.EndGame();

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
                case GameModes._4PlayerFFA:
                    framework_Game = new _4PlayerFFA(this, demoMode, mapData);
                    break;
            }

            if (framework_Game != null) { Panel.SetZIndex(framework_Game.GetGame_Grid(), 0); }
            if (framework_Menu != null) { Panel.SetZIndex(framework_Menu.GetMenu_Canvas(), 1); }
        }

        public void ChangeMenu(Menus menu)
        {
            if (framework_Menu != null) { framework_Canvas.Children.Remove(framework_Menu.GetMenu_Canvas()); }

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

            if (framework_Game != null) { Panel.SetZIndex(framework_Game.GetGame_Grid(), 0); }
            if (framework_Menu != null) { Panel.SetZIndex(framework_Menu.GetMenu_Canvas(), 1); }
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
        public void SetFramework_MapDataList(List<MapData> mapDataList)
        {
            framework_MapDataList = mapDataList;
            //Sets the mapDataList.
        }
    }
}
