using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Metal_Lynch__v3._0_
{
    public class Grenade : Projectile
    {
        private EllipseGeometry grenade_ExplosionGeometry;
        private Path grenade_ExplosionPath;

        private RotateTransform grenade_RotateTransform;

        private BitmapImage grenade_Sprite;

        private int grenade_ImpactDamage;
        private int grenade_ExplosionDamage;

        private BitmapImage grenade_ExplosionSpriteSheet;
        private CroppedBitmap[] grenade_ExplosionSpriteArray;
        private int grenade_AnimationIncrement;

        public Grenade(Game game)
        {
            BaseConstructor(game);

            grenade_RotateTransform = new RotateTransform();

            geometry = new EllipseGeometry()
            {
                Transform = projectile_TransformGroup,
                RadiusX = 20,
                RadiusY = 20
            };

            grenade_Sprite = new BitmapImage(
                new Uri(@"Resources/Grenade sprite.png", UriKind.Relative));

            path = new Path()
            {
                Stroke = Brushes.Black,
                Fill = new ImageBrush(new TransformedBitmap(
                    grenade_Sprite, grenade_RotateTransform))
                {
                    Stretch = Stretch.Uniform
                },
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

            grenade_ImpactDamage = 20;
            grenade_ExplosionDamage = 15;
            projectile_Damage = grenade_ImpactDamage;

            projectile_Speed = 0.07;

            grenade_ExplosionSpriteSheet = new BitmapImage(
                new Uri(@"Resources/Explosion spritesheet.png", UriKind.Relative)
                );

            grenade_ExplosionSpriteArray = new CroppedBitmap[20];
            for (int i = 0; i < 20; i++)
            {
                grenade_ExplosionSpriteArray[i] =
                    new CroppedBitmap(
                        grenade_ExplosionSpriteSheet,
                        new Int32Rect((i * 192) % 768, (i / 5) * 192, 192, 192));
            }

            grenade_AnimationIncrement = 0;
        }

        public override void MoveAlongTrajectory(double gravity)
        {
            gravity *= 1.3;
            base.MoveAlongTrajectory(gravity);

            grenade_RotateTransform.CenterX = projectile_TranslateTransform.X;
            grenade_RotateTransform.CenterY = projectile_TranslateTransform.Y;

            if (projectile_AngleRadians < Math.PI / 2)
                { grenade_RotateTransform.Angle += 4; }
            else { grenade_RotateTransform.Angle -= 4; }

            path.Fill.Transform = grenade_RotateTransform;
        }

        public override int Impact(Tank currentPlayer, Tank[] enemyTankArray)
        {
            game.PlayExplosionSound();

            int damage = 0;

            projectile_Finished = false;
            projectile_Detonated = true;

            RemoveFromCanvas();

            game.GetGame_MainCanvas().Children.Add(
                grenade_ExplosionPath);

            grenade_AnimationIncrement = 0;

            CompositionTarget.Rendering += AnimationEvent;
            
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

        private void AnimationEvent(object sender, EventArgs e)
        {
            grenade_ExplosionPath.Fill = new ImageBrush(
                grenade_ExplosionSpriteArray[grenade_AnimationIncrement])
            {
                Stretch = Stretch.UniformToFill
            };
            grenade_AnimationIncrement++;

            if (grenade_AnimationIncrement > 19)
            {
                CompositionTarget.Rendering -= AnimationEvent;

                game.GetGame_MainCanvas().Children.Remove(
                    grenade_ExplosionPath);

                projectile_Finished = true;
                projectile_Detonated = false;
            }
        }
    }
}
