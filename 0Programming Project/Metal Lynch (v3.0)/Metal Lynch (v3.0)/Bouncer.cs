using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public class Bouncer : Projectile
    {
        private Uri bouncer_SoftHitSoundUri;

        private int bounces;
        private int bouncer_BaseDamage;

        public Bouncer(Game game)
        {
            BaseConstructor(game);

            bouncer_SoftHitSoundUri = new Uri(@"Resources/Soft Hit sound effect.mp3", UriKind.Relative);

            geometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 8,
                RadiusY = 8
            };
            path = new Path()
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.Blue,
                StrokeThickness = 2,
                Data = geometry
            };

            bouncer_BaseDamage = 8;
            projectile_Damage = bouncer_BaseDamage;

            bounces = 0;
        }

        public override int Impact(Tank currentPlayer, Tank[] enemyTankArray)
        {
            bounces++;

            projectile_Finished = false;

            projectile_Damage = bouncer_BaseDamage * bounces;

            foreach (Tank tank in enemyTankArray)
            {
                IntersectionDetail projectileEnemyIntersection =
                    geometry.FillContainsWithDetail
                    (tank.GetGeometry());

                if (projectileEnemyIntersection == IntersectionDetail.Intersects)
                {
                    game.PlayExplosionSound();
                    bounces = 0;
                    projectile_Finished = true;
                    currentPlayer.DealDamage(this);
                    return tank.TakeDamage(this);
                }
            }

            projectile_Damage = bouncer_BaseDamage;

            if (bounces >= 3)
            {
                game.PlayExplosionSound();
                bounces = 0;
                projectile_Finished = true;
                return 0;
            }

            game.PlaySound(bouncer_SoftHitSoundUri);

            if (projectile_AngleRadians > Math.PI)
            {
                projectile_AngleRadians = Math.PI - (projectile_AngleRadians - Math.PI);
            }
            else if (projectile_AngleRadians < 0)
            {
                projectile_AngleRadians = Math.Abs(projectile_AngleRadians);
            }
            
            SetAndStartTrajectory(
                new Point(projectile_TranslateTransform.X, projectile_TranslateTransform.Y - 20),
                projectile_AngleRadians,
                projectile_InitialVelocity * 0.9);

            return 0;
        }

        public override void StopTrajectory()
        {
            base.StopTrajectory();
            bounces = 0;
        }
    }
}
