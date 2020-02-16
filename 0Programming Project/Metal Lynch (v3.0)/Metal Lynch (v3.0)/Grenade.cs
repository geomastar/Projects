using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Metal_Lynch__v3._0_
{
    public class Grenade : Projectile
    {
        private EllipseGeometry grenade_ExplosionGeometry;
        private Path grenade_ExplosionPath;

        private int grenade_ImpactDamage;
        private int grenade_ExplosionDamage;

        public Grenade(Game game)
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
                Stroke = Brushes.Brown,
                Fill = Brushes.Brown,
                StrokeThickness = 2,
                Data = geometry
            };

            grenade_ExplosionGeometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 80,
                RadiusY = 80
            };
            grenade_ExplosionPath = new Path()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Data = grenade_ExplosionGeometry
            };

            game.GetGame_MainCanvas().Children.Add(
                grenade_ExplosionPath);

            grenade_ImpactDamage = 20;
            grenade_ExplosionDamage = 15;
            projectile_Damage = grenade_ImpactDamage;
        }

        public override int Impact(Tank currentPlayer, Tank[] enemyTankArray)
        {
            int damage = 0;

            projectile_Damage = grenade_ExplosionDamage;

            foreach (Tank tank in enemyTankArray)
            {
                IntersectionDetail tankExplosionIntersection =
                    tank.GetGeometry().FillContainsWithDetail(
                        grenade_ExplosionGeometry);

                if (tankExplosionIntersection == IntersectionDetail.Intersects ||
                    tankExplosionIntersection == IntersectionDetail.FullyInside ||
                    tankExplosionIntersection == IntersectionDetail.FullyContains)
                {
                    tank.TakeDamage(this);
                    currentPlayer.DealDamage(this);
                    damage += projectile_Damage;
                }
            }

            projectile_Damage = grenade_ImpactDamage;

            return damage;
        }
    }
}
