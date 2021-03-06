﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public class Shot : Projectile
    {
        public Shot(Game game)
        {
            BaseConstructor(game);

            geometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 8,
                RadiusY = 8
            };
            path = new Path()
            {
                Stroke = Brushes.DarkRed,
                Fill = Brushes.DarkRed,
                StrokeThickness = 2,
                Data = geometry
            };

            projectile_Damage = 20;
        }

        public override int Impact(Tank currentPlayer, Tank[] enemyTankArray)
        {
            return base.Impact(currentPlayer, enemyTankArray);
        }
    }
}
