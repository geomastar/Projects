using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metal_Lynch__v3._0_
{
    public class AirStrike : Projectile
    {
        private Missile[] airStrike_MissileArray;

        private Tank airStrike_CurrentPlayer;
        private Tank[] airStrike_EnemyTankArray;

        private Uri airStrike_SoftHitSoundUri;

        private int airStrike_TotalDamage;

        private int airStrike_AnimationIncrement;

        public AirStrike(Game game)
        {
            BaseConstructor(game);

            airStrike_SoftHitSoundUri = new Uri(@"Resources/Soft Hit sound effect.mp3", UriKind.Relative);

            geometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 7,
                RadiusY = 7
            };
            path = new Path()
            {
                Stroke = Brushes.OrangeRed,
                Fill = Brushes.OrangeRed,
                StrokeThickness = 2,
                Data = geometry
            };

            projectile_Damage = 0;

            airStrike_MissileArray = new Missile[7];
            for (int i = 0; i < airStrike_MissileArray.Length; i++)
            {
                airStrike_MissileArray[i] = new Missile(game);
            }

            airStrike_AnimationIncrement = 0;
        }

        public override int Impact(Tank currentPlayer, Tank[] enemyTankArray)
        {
            game.PlaySound(airStrike_SoftHitSoundUri);

            projectile_Finished = false;
            projectile_Detonated = true;

            airStrike_AnimationIncrement = 0;

            airStrike_CurrentPlayer = currentPlayer;
            airStrike_EnemyTankArray = enemyTankArray;

            CompositionTarget.Rendering += AnimationEvent;

            return 0;
        }

        private void AnimationEvent(object sender, EventArgs e)
        {
            airStrike_AnimationIncrement++;

            if (airStrike_AnimationIncrement > 60)
            {
                CompositionTarget.Rendering -= AnimationEvent;

                double xSpacing = 30;
                double x = projectile_TranslateTransform.X - (xSpacing * 3);
                double y = 1;
                foreach (Missile missile in airStrike_MissileArray)
                {
                    missile.SetAndStartTrajectory(new Point(x, 30 - (Math.Abs(4 - y) * 10)),
                        Math.PI / -2,
                        0);

                    x += xSpacing;
                    y += 1;
                }

                CompositionTarget.Rendering += MissileEvent;
            }
        }

        private void MissileEvent(object sender, EventArgs e)
        {
            bool fin = true;

            foreach (Missile missile in airStrike_MissileArray)
            {
                if (missile.GetProjectile_InMotion())
                {
                    fin = false;                   

                    if (!missile.GetProjectile_Detonated())
                    {
                        missile.MoveAlongTrajectory(game.GetGame_Gravity());
                    }

                    IntersectionDetail projectileMapIntersection =
                        missile.GetGeometry().FillContainsWithDetail
                        (game.GetGame_Map().GetGeometry());

                    bool enemyHit = false;
                    foreach (Tank tank in airStrike_EnemyTankArray)
                    {
                        IntersectionDetail projectileEnemyIntersection =
                            missile.GetGeometry().FillContainsWithDetail
                            (tank.GetGeometry());

                        if (projectileEnemyIntersection == IntersectionDetail.Intersects
                            && !enemyHit)
                        {
                            if (!missile.GetProjectile_Detonated())
                            {
                                game.PlayExplosionSound();

                                airStrike_TotalDamage += missile.Impact(airStrike_CurrentPlayer, airStrike_EnemyTankArray);
                            }

                            if (missile.GetProjectile_Finished())
                            {
                                missile.StopTrajectory();
                                tank.TakeDamage(missile);
                                airStrike_CurrentPlayer.DealDamage(missile);
                            }

                            enemyHit = true;
                        }
                    }

                    if ((projectileMapIntersection == IntersectionDetail.Intersects | projectileMapIntersection == IntersectionDetail.FullyInside)
                        && !enemyHit)
                    {
                        if (!missile.GetProjectile_Detonated())
                        {
                            game.PlayExplosionSound();

                            missile.Impact(airStrike_CurrentPlayer, airStrike_EnemyTankArray);
                        }

                        if (missile.GetProjectile_Finished())
                        {
                            missile.StopTrajectory();
                        }
                    }
                    else if ((missile.GetProjectile_TranslateTransform().X < game.GetGame_Boundaries()[0] |
                        missile.GetProjectile_TranslateTransform().X > game.GetGame_Boundaries()[1])
                        && !enemyHit)
                    {
                        missile.StopTrajectory();
                    }
                }
            }

            if (fin)
            {
                CompositionTarget.Rendering -= MissileEvent;

                projectile_Finished = true;
                projectile_Detonated = false;

                game.EndTurn(airStrike_TotalDamage);

                airStrike_TotalDamage = 0;
            }
        }



        private class Missile : Projectile
        {
            private BitmapImage missile_Sprite;

            public Missile(Game game)
            {
                BaseConstructor(game);

                geometry = new RectangleGeometry()
                {
                    Transform = projectile_TransformGroup,
                    Rect = new Rect(new Size(15, 50))
                };

                missile_Sprite = new BitmapImage(
                    new Uri(@"Resources/Missile sprite.png", UriKind.Relative));

                path = new Path()
                {
                    Stroke = Brushes.DarkRed,
                    Fill = new ImageBrush(missile_Sprite),
                    StrokeThickness = 2,
                    Data = geometry
                };

                projectile_Damage = 15;
            }

            public override int Impact(Tank currentPlayer, Tank[] enemyTankArray)
            {
                game.PlayExplosionSound();

                projectile_Finished = true;
                return projectile_Damage;
            }
        }
    }
}
