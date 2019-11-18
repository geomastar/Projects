﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v2._0_
{
    public abstract class GameObject
    {
        protected Game game;

        protected Path path;
        protected Geometry geometry;

        protected void AddToCanvas()
        {
            game.Getgame_MainCanvas().Children.Add(path);
            //Adds the object's Path to the Canvas of the Game that
            //it belongs to.
        }

        protected void RemoveFromCanvas()
        {
            game.Getgame_MainCanvas().Children.Remove(path);
            //Removes the object's Path from the Canvas of the Game that
            //it belongs to.
        }

        public Path GetPath()
        {
            return path;
            //returns the GameObject's Path object.
        }

        public Geometry GetGeometry()
        {
            return geometry;
            //returns the GameObject's Geometry object.
        }
    }
}
