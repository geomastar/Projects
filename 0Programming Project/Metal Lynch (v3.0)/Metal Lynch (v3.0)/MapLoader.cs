using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Metal_Lynch__v3._0_
{
    public class MapLoader : Game
    {
        AngleMeasurer mapLoader_AngleMeasurer;

        private List<Framework.MapData> mapLoader_MapDataList;
        private int mapLoader_CurrentMapIndex;
        private int mapLoader_Step;
        private bool mapLoader_CalculatingAngles;

        public MapLoader(Framework framework)
        {
            game_Framework = framework;

            mapLoader_MapDataList = new List<Framework.MapData>();
            mapLoader_CurrentMapIndex = 0;

            mapLoader_Step = 20;

            mapLoader_CalculatingAngles = true;

            ReadMapDataFromFile();

            game_MainCanvas = new Canvas()
            {
                Height = 450,
                Width = 1280,
            };
            game_GUICanvas = new Canvas()
            {
                Height = 240,
                Width = 1280,
            };

            game_Grid = new Grid()
            {
                Height = 690,
                Width = 1280,
            };

            game_MainRow = new RowDefinition() { Height = new GridLength(450) };
            game_Grid.RowDefinitions.Add(game_MainRow);
            Grid.SetRow(game_MainCanvas, 0);
            game_Grid.Children.Add(game_MainCanvas);

            game_GUIRow = new RowDefinition() { Height = new GridLength(240) };
            game_Grid.RowDefinitions.Add(game_GUIRow);
            Grid.SetRow(game_GUICanvas, 1);
            game_Grid.Children.Add(game_GUICanvas);

            game_Map = new Map(this, mapLoader_MapDataList[mapLoader_CurrentMapIndex]);
            mapLoader_AngleMeasurer = new AngleMeasurer(this, mapLoader_Step);

            game_RightBoundary = 1280;

            game_NewTurn = false;
            game_Gravity = 10;
            game_Turn = 1;

            AddToCanvas();

            while (mapLoader_CalculatingAngles)
            {
                UpdateEvent(1, new EventArgs());
            }
        }

        protected override void UpdateEvent(object sender, EventArgs e)
        {
            int i = game_Gravity;
            bool intersectionFound = false;

            while (i > 0 & !intersectionFound)
            {
                mapLoader_AngleMeasurer.MoveDown();

                IntersectionDetail angleMeasurerMapIntersection =
                    mapLoader_AngleMeasurer.GetGeometry().
                    FillContainsWithDetail(game_Map.GetGeometry());

                if (angleMeasurerMapIntersection == IntersectionDetail.Intersects)
                {
                    mapLoader_AngleMeasurer.MoveUp();
                    mapLoader_AngleMeasurer.MoveUp();
                    intersectionFound = true;
                    mapLoader_AngleMeasurer.angleMeasurer_Start = true;
                }

                i--;
            }

            if (game_NewTurn)
            {
                mapLoader_CurrentMapIndex++;
                if (mapLoader_CurrentMapIndex == mapLoader_MapDataList.Count)
                {
                    mapLoader_CalculatingAngles = false;
                }
                else
                {
                    game_MainCanvas.Children.Remove(game_Map.GetPath());
                    game_Map = new Map(this, mapLoader_MapDataList[mapLoader_CurrentMapIndex]);

                    mapLoader_AngleMeasurer.ResetPosition();
                    mapLoader_AngleMeasurer.angleMeasurer_AngleList = new List<double>();
                    mapLoader_AngleMeasurer.angleMeasurer_Start = false;
                }
                game_NewTurn = false;
            }
            else
            {
                if (mapLoader_AngleMeasurer.angleMeasurer_TranslateTransform.X >= game_RightBoundary)
                {
                    string mapName = mapLoader_MapDataList[mapLoader_CurrentMapIndex].mapName;
                    Point[] mapPointArray = mapLoader_MapDataList[mapLoader_CurrentMapIndex].pointArray;

                    mapLoader_MapDataList[mapLoader_CurrentMapIndex] =
                        new Framework.MapData(mapName, mapPointArray, mapLoader_Step)
                        { angleArray = mapLoader_AngleMeasurer.angleMeasurer_AngleList.ToArray() };

                    game_NewTurn = true;
                }
                else if (mapLoader_AngleMeasurer.angleMeasurer_Start)
                {
                    mapLoader_AngleMeasurer.angleMeasurer_PrevY =
                        mapLoader_AngleMeasurer.angleMeasurer_TranslateTransform.Y;

                    for (int s = 0; s < mapLoader_Step; s++)
                    {
                        mapLoader_AngleMeasurer.MoveRight();

                        int j = game_Gravity;
                        intersectionFound = false;

                        while (j > 0 & !intersectionFound)
                        {
                            mapLoader_AngleMeasurer.MoveDown();

                            IntersectionDetail angleMeasurerMapIntersection =
                                mapLoader_AngleMeasurer.GetGeometry().
                                FillContainsWithDetail(game_Map.GetGeometry());

                            if (angleMeasurerMapIntersection == IntersectionDetail.Intersects)
                            {
                                mapLoader_AngleMeasurer.MoveUp();
                                mapLoader_AngleMeasurer.MoveUp();
                                intersectionFound = true;
                            }

                            j--;
                        }
                    }

                    mapLoader_AngleMeasurer.CalculateNextAngle();
                }
            }
        }

        public override void EndGame()
        {
            game_Framework.SetFramework_MapDataList(mapLoader_MapDataList);

            Random RNG = new Random();
            switch (RNG.Next(2))
            {
                case (0):
                    game_Framework.ChangeGameMode(Framework.GameModes.Training, true,
                        game_Framework.GetFramework_MapDataList()
                        [(RNG.Next(game_Framework.GetFramework_MapDataList().Count))]);
                    break;
                case (1):
                    game_Framework.ChangeGameMode(Framework.GameModes._1v1, true,
                        game_Framework.GetFramework_MapDataList()
                        [(RNG.Next(game_Framework.GetFramework_MapDataList().Count))]);
                    break;
            }

            game_Framework.ChangeMenu(Framework.Menus.MainMenu);
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

                    mapLoader_MapDataList.Add(new Framework.MapData(name, points, mapLoader_Step));
                }
            }

            if (mapLoader_MapDataList.Count == 0)
            {
                mapLoader_MapDataList.Add(new Framework.MapData("Flat", new Point[] { new Point(0, 300), new Point(0, 300), new Point(1265, 300), new Point(1265, 300) }, mapLoader_Step));
            }
        }



        private class AngleMeasurer : GameObject
        {
            public int angleMeasurer_Step;
            public double angleMeasurer_PrevY;
            public List<double> angleMeasurer_AngleList;
            public bool angleMeasurer_Start;

            public TranslateTransform angleMeasurer_TranslateTransform;

            public AngleMeasurer(MapLoader mapLoader, int step)
            {
                game = mapLoader;

                angleMeasurer_Step = step;

                angleMeasurer_AngleList = new List<double>();

                angleMeasurer_Start = false;

                angleMeasurer_TranslateTransform = new TranslateTransform(0, 0);

                geometry = new EllipseGeometry()
                {
                    Transform = angleMeasurer_TranslateTransform,
                    RadiusX = 5,
                    RadiusY = 5
                };

                path = new System.Windows.Shapes.Path()
                {
                    Stroke = Brushes.Red,
                    Fill = Brushes.Red,
                    StrokeThickness = 2,
                    Data = geometry
                };

                AddToCanvas();
            }

            public void CalculateNextAngle()
            {
                double changeInY;

                changeInY =
                    angleMeasurer_TranslateTransform.Y -
                    angleMeasurer_PrevY;

                double angle =
                    Math.Atan(changeInY / angleMeasurer_Step) * (180 / Math.PI);

                angleMeasurer_AngleList.Add(angle);

                //Debug.WriteLine(angleMeasurer_PrevY + "   =>   " + angleMeasurer_TranslateTransform.Y);
            }

            public void ResetPosition()
            {
                angleMeasurer_TranslateTransform = new TranslateTransform(0, 0);
                geometry.Transform = angleMeasurer_TranslateTransform;
            }

            public void MoveUp()
            {
                angleMeasurer_TranslateTransform.Y -= 1;
            }
            public void MoveDown()
            {
                angleMeasurer_TranslateTransform.Y += 1;
            }
            public void MoveRight()
            {
                angleMeasurer_TranslateTransform.X += 1;
            }
        }
    }
}
